using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace SCILL
{
    public enum Environment
    {
        Production,
        Staging,
        Development
    }

    public class SCILLClient
    {
        public string AccessToken { get; private set; }
        public string AppId { get; private set; }
        public string Language { get; private set; }

        public EventsApi EventsApi => _EventsApi.Value;
        public ChallengesApi ChallengesApi => _ChallengesApi.Value;
        public BattlePassesApi BattlePassesApi => _BattlePassesApi.Value;
        public AuthApi AuthApi => _AuthApi.Value;
        public LeaderboardsApi LeaderboardsApi => _LeaderboardsApi.Value;

        private Lazy<EventsApi> _EventsApi;
        private Lazy<ChallengesApi> _ChallengesApi;
        private Lazy<BattlePassesApi> _BattlePassesApi;
        private Lazy<AuthApi> _AuthApi;
        private Lazy<LeaderboardsApi> _LeaderboardsApi;

        private static Configuration Config;

        private List<IMqttClient> _mqttClients = new List<IMqttClient>();
        private readonly MqttFactory _mqttFactory = new MqttFactory();

        private IMqttClient _challengesMqttClient;
        private Dictionary<String, IMqttClient> _battlePassMqttClients = new Dictionary<string, IMqttClient>();
    
        public delegate void ChallengeChangedNotificationHandler(ChallengeWebhookPayload payload);
        public event ChallengeChangedNotificationHandler OnChallengeChangedNotification;

        public delegate void BattlePassChangedNotificationHandler(BattlePassChallengeChangedPayload payload);

        public event BattlePassChangedNotificationHandler OnBattlePassChangedNotification;

        public SCILLClient(string accessToken, string appId, string language = null, Environment environment = Environment.Production)
        {
            AccessToken = accessToken;
            AppId = appId;
            Language = language;

            string hostSuffix = "";
            if (environment == Environment.Staging)
            {
                hostSuffix = "-staging";
            } else if (environment == Environment.Development)
            {
                hostSuffix = "-dev";
            }

            _EventsApi = new Lazy<EventsApi>(() => GetApi<EventsApi>(AccessToken, "https://ep" + hostSuffix + ".scillgame.com"), true);
            _ChallengesApi = new Lazy<ChallengesApi>(() => GetApi<ChallengesApi>(AccessToken, "https://pcs" + hostSuffix + ".scillgame.com"), true);
            _BattlePassesApi = new Lazy<BattlePassesApi>(() => GetApi<BattlePassesApi>(AccessToken, "https://es" + hostSuffix + ".scillgame.com"), true);
            _AuthApi = new Lazy<AuthApi>(() => GetApi<AuthApi>(accessToken, "https://us" + hostSuffix + ".scillgame.com"), true);
            _LeaderboardsApi = new Lazy<LeaderboardsApi>(() => GetApi<LeaderboardsApi>(accessToken, "https://ls" + hostSuffix + ".scillgame.com"), true);

            Config = Configuration.Default.Clone(string.Empty, Configuration.Default.BasePath);
            Config.ApiKey[this.ToString()] = AccessToken;
            
            // On client side, the event parser is set to use the access token to authenticate the request
            Config.AddApiKey("auth", "access_token");
        }

        ~SCILLClient()
        { 
            StopMonitoring();
        }

        private T GetApi<T>(string token, string basePath) where T : IApiAccessor
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { Config.Clone(token, basePath) });
        }

        #region Realtime Updates
        
        private IMqttClient CreateMQTTClient()
        {
            var client = _mqttFactory.CreateMqttClient();
            _mqttClients.Add(client);
            return client;
        }

        public void StartChallengeUpdateNotifications(ChallengeChangedNotificationHandler handler)
        {
            OnChallengeChangedNotification += handler;

            if (_challengesMqttClient == null)
            {
                StartMonitorUserChallenges();
            }
        }

        public void StopChallengeUpdateNotifications(ChallengeChangedNotificationHandler handler)
        {
            OnChallengeChangedNotification -= handler;

            if (OnChallengeChangedNotification == null || OnChallengeChangedNotification?.GetInvocationList().Length <= 0)
            {
                StopMonitorUserChallenges();
            }
        }

        public void StartBattlePassUpdateNotifications(string battlePassId, BattlePassChangedNotificationHandler handler)
        {
            OnBattlePassChangedNotification += handler;

            if (!_battlePassMqttClients.ContainsKey(battlePassId))
            {
                StartMonitorBattlePass(battlePassId);
            }
        }
        
        public void StopBattlePassUpdateNotifications(string battlePassId, BattlePassChangedNotificationHandler handler)
        {
            OnBattlePassChangedNotification -= handler;

            if (OnBattlePassChangedNotification == null || OnBattlePassChangedNotification?.GetInvocationList().Length <= 0)
            {
                StopMonitorBattlePass(battlePassId);
            }
        }

        private async void StartMonitorUserChallenges()
        {
            _challengesMqttClient = CreateMQTTClient();

            // Subscribe to that topic once the MQTT connection is established
            _challengesMqttClient.UseConnectedHandler(async e =>
            {
                // Get the MQTT topic for listening on changes for the challenges
                var notificationTopic = await AuthApi.GetUserChallengesNotificationTopicAsync();

                // Subscribe to a topic
                await _challengesMqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic(notificationTopic.topic).Build());
            });

            // Handle incoming messages and send payloads to callback handler
            _challengesMqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                string jsonStr = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                var payload = JsonConvert.DeserializeObject<ChallengeWebhookPayload>(jsonStr);
                if (payload != null)
                {
                    OnChallengeChangedNotification?.Invoke(payload);
                }
            });

            // Connect to SCILLs MQTT server to receive real time notifications
            var options = new MqttClientOptionsBuilder()
                .WithWebSocketServer("mqtt.scillgame.com:8083/mqtt")
                .WithTls()
                .Build();

            await _challengesMqttClient.ConnectAsync(options, CancellationToken.None);
        }

        private async void StopMonitorUserChallenges()
        {
            if (_challengesMqttClient == null)
            {
                return;
            }

            await _challengesMqttClient.DisconnectAsync();
            _mqttClients.Remove(_challengesMqttClient);
            _challengesMqttClient = null;
        }
        
        private async void StartMonitorBattlePass(string battlePassId)
        {
            // Check if we already listen to this leaderboard
            if (_battlePassMqttClients.ContainsKey(battlePassId))
            {
                return;
            }
            
            var client = CreateMQTTClient();
            _battlePassMqttClients.Add(battlePassId, client);

            // Subscribe to that topic once the MQTT connection is established
            client.UseConnectedHandler(async e =>
            {
                // Get the MQTT topic for listening on changes for the challenges
                var notificationTopic = await AuthApi.GetUserBattlePassNotificationTopicAsync(battlePassId);

                // Subscribe to the returned topic
                await client.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic(notificationTopic.topic).Build());
            });

            // Handle incoming messages and send payloads to callback handler
            client.UseApplicationMessageReceivedHandler(e =>
            {
                string jsonStr = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                var payload = JsonConvert.DeserializeObject<BattlePassChallengeChangedPayload>(jsonStr);
                if (payload != null)
                {
                    OnBattlePassChangedNotification?.Invoke(payload);
                }
            });

            // Connect to SCILLs MQTT server to receive real time notifications
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("mqtt.scillgame.com", 1883)
                .Build();

            await client.ConnectAsync(options, CancellationToken.None);
        }
        
        private async void StopMonitorBattlePass(string battlePassId)
        {
            if (_battlePassMqttClients.ContainsKey(battlePassId))
            {
                await _battlePassMqttClients[battlePassId].DisconnectAsync();
                _battlePassMqttClients.Remove(battlePassId);
            }
        }

        private async void StopMonitoring()
        {
            foreach (var client in _mqttClients)
            {
                await client.DisconnectAsync();
            }
            _mqttClients.Clear();
        }

        #endregion
        
        #region AuthApi

        public NotificationTopic GetUserChallengeNotificationTopic(string challengeId = null)
        {
            return AuthApi.GetUserChallengeNotificationTopic(challengeId);
        }
        
        #endregion
        
        #region EventApi
        public ActionResponse SendEvent(EventPayload payload)
        {
            return SendEventAsync(payload)
                .GetAwaiter()
                .GetResult();
        }

        public async Task<ActionResponse> SendEventAsync(EventPayload payload)
        {
            return await EventsApi.SendEventAsync(payload);
        }
        #endregion EventApi

        #region ChallengesApi
        public ActionResponse ActivatePersonalChallenge(string challengeId)
        {
            return ChallengesApi.ActivatePersonalChallenge(AppId, challengeId);
        }

        public async Task<ActionResponse> ActivatePersonalChallengeAsync(string challengeId)
        {
            return await ChallengesApi.ActivatePersonalChallengeAsync(AppId, challengeId);
        }

        public ActionResponse CancelPersonalChallenge(string challengeId)
        {
            return ChallengesApi.CancelPersonalChallenge(AppId, challengeId);
        }

        public async Task<ActionResponse> CancelPersonalChallengeAsync(string challengeId)
        {
            return await ChallengesApi.CancelPersonalChallengeAsync(AppId, challengeId);
        }

        public ActionResponse ClaimPersonalChallengeReward(string challengeId)
        {
            return ChallengesApi.ClaimPersonalChallengeReward(AppId, challengeId);
        }

        public async Task<ActionResponse> ClaimPersonalChallengeRewardAsync(string challengeId)
        {
            return await ChallengesApi.ClaimPersonalChallengeRewardAsync(AppId, challengeId);
        }

        public List<ChallengeCategory> GetPersonalChallenges (List<string> includeCategories = null, List<string> excludeCategories = null)
        {
            return ChallengesApi.GetPersonalChallenges(AppId, includeCategories, excludeCategories, Language);
        }

        public async Task<List<ChallengeCategory>> GetPersonalChallengesAsync (List<string> includeCategories = null, List<string> excludeCategories = null)
        {
            return await ChallengesApi.GetPersonalChallengesAsync(AppId, includeCategories, excludeCategories, Language);
        }
        
        public List<ChallengeCategory> GetAllPersonalChallenges (List<string> includeCategories = null, List<string> excludeCategories = null)
        {
            return ChallengesApi.GetAllPersonalChallenges(AppId, includeCategories, excludeCategories, Language);
        }

        public async Task<List<ChallengeCategory>> GetAllPersonalChallengesAsync (List<string> includeCategories = null, List<string> excludeCategories = null)
        {
            return await ChallengesApi.GetAllPersonalChallengesAsync(AppId, includeCategories, excludeCategories, Language);
        }        
        
        
        public List<ChallengeCategory> GetUnresolvedPersonalChallenges (List<string> includeCategories = null, List<string> excludeCategories = null)
        {
            return ChallengesApi.GetUnresolvedPersonalChallenges(AppId, includeCategories, excludeCategories, Language);
        }

        public async Task<List<ChallengeCategory>> GetUnresolvedPersonalChallengesAsync(List<string> includeCategories = null, List<string> excludeCategories = null)
        {
            return await ChallengesApi.GetUnresolvedPersonalChallengesAsync(AppId, includeCategories, excludeCategories, Language);
        }               
        
        public Challenge GetPersonalChallengeById(string challengeId)
        {
            return ChallengesApi.GetPersonalChallengeById(AppId, challengeId, Language);
        }

        public async Task<Challenge> GetPersonalChallengeByIdAsync(string challengeId)
        {
            return await ChallengesApi.GetPersonalChallengeByIdAsync(AppId, challengeId, Language);
        }

        public List<ChallengeCategory> GetActivePersonalChallenges()
        {
            return ChallengesApi.GetActivePersonalChallenges(AppId, Language);
        }

        public async Task<List<ChallengeCategory>> GetActivePersonalChallengesAsync()
        {
            return await ChallengesApi.GetActivePersonalChallengesAsync(AppId, Language);
        }

        public ActionResponse UnlockPersonalChallenge(string challengeId)
        {
            return ChallengesApi.UnlockPersonalChallenge(AppId, challengeId, Language);
        }

        public async Task<ActionResponse> UnlockPersonalChallengeAsync(string challengeId)
        {
            return await ChallengesApi.UnlockPersonalChallengeAsync(AppId, challengeId, Language);
        }

        #endregion ChallengesApi
        
        #region BattlePassesApi

        public ActionResponse ActivateBattlePassLevel(string levelId)
        {
            return BattlePassesApi.ActivateBattlePassLevel(AppId, levelId, Language);
        }
        
        public async Task<ActionResponse> ActivateBattlePassLevelAsync(string levelId)
        {
            return await BattlePassesApi.ActivateBattlePassLevelAsync(AppId, levelId, Language);
        }

        public ActionResponse ClaimBattlePassLevelReward(string levelId)
        {
            return BattlePassesApi.ClaimBattlePassLevelReward(AppId, levelId, Language);
        }

        public async Task<ActionResponse> ClaimBattlePassLevelRewardAsync(string levelId)
        {
            return await BattlePassesApi.ClaimBattlePassLevelRewardAsync(AppId, levelId, Language);
        }

        public List<BattlePass> GetActiveBattlePasses()
        {
            return BattlePassesApi.GetActiveBattlePasses(AppId, Language);
        }

        public async Task<List<BattlePass>> GetActiveBattlePassesAsync()
        {
            return await BattlePassesApi.GetActiveBattlePassesAsync(AppId, Language);
        }

        public List<BattlePassLevel> GetAllBattlePassLevels()
        {
            return BattlePassesApi.GetAllBattlePassLevels(AppId, Language);
        }
        
        public async Task<List<BattlePassLevel>> GetAllBattlePassLevelsAsync()
        {
            return await BattlePassesApi.GetAllBattlePassLevelsAsync(AppId, Language);
        }

        public BattlePass GetBattlePass(string battlePassId)
        {
            return BattlePassesApi.GetBattlePass(AppId, battlePassId, Language);
        }

        public async Task<BattlePass> GetBattlePassAsync(string battlePassId)
        {
            return await BattlePassesApi.GetBattlePassAsync(AppId, battlePassId, Language);
        }
        
        public List<BattlePassLevel> GetBattlePassLevels(string battlePassId)
        {
            return BattlePassesApi.GetBattlePassLevels(AppId, battlePassId, Language);
        }
        
        public async Task<List<BattlePassLevel>> GetBattlePassLevelsAsync(string battlePassId)
        {
            return await BattlePassesApi.GetBattlePassLevelsAsync(AppId, battlePassId, Language);
        }

        public List<BattlePass> GetBattlePasses()
        {
            return BattlePassesApi.GetBattlePasses(AppId, Language);
        }
        
        public async Task<List<BattlePass>> GetBattlePassesAsync()
        {
            return await BattlePassesApi.GetBattlePassesAsync(AppId, Language);
        }

        public List<BattlePass> GetUnlockedBattlePasses()
        {
            return BattlePassesApi.GetUnlockedBattlePasses(AppId, Language);
        }
        
        public async Task<List<BattlePass>> GetUnlockedBattlePassesAsync()
        {
            return await BattlePassesApi.GetUnlockedBattlePassesAsync(AppId, Language);
        }

        public BattlePassUnlockInfo UnlockBattlePass(string battlePassId,
            BattlePassUnlockPayload body = null)
        {
            return BattlePassesApi.UnlockBattlePass(AppId, battlePassId, body, Language);
        }
        
        public async Task<BattlePassUnlockInfo> UnlockBattlePassAsync(string battlePassId,
            BattlePassUnlockPayload body = null)
        {
            return await BattlePassesApi.UnlockBattlePassAsync(AppId, battlePassId, body, Language);
        }
        
        #endregion BattlePassesApi
        
        #region LeaderboardsApi

        public Leaderboard GetLeaderboard(string leaderboardId, int? currentPage = null, int? pageSize = null)
        {
            return LeaderboardsApi.GetLeaderboard(leaderboardId, currentPage, pageSize, Language);
        }

        public Task<Leaderboard> GetLeaderboardAsync(string leaderboardId, int? currentPage = null,
            int? pageSize = null)
        {
            return LeaderboardsApi.GetLeaderboardAsync(leaderboardId, currentPage, pageSize, Language);
        }

        public LeaderboardMemberRanking GetLeaderboardRanking(string memberType, string memberId,
            string leaderboardId)
        {
            return LeaderboardsApi.GetLeaderboardRanking(memberType, memberId, leaderboardId, Language);
        }

        public Task<LeaderboardMemberRanking> GetLeaderboardRankingAsync(string memberType,
            string memberId, string leaderboardId)
        {
            return LeaderboardsApi.GetLeaderboardRankingAsync(memberType, memberId, leaderboardId, Language);
        }

        public List<LeaderboardMemberRanking> GetLeaderboardRankings(string memberType, string memberId)
        {
            return LeaderboardsApi.GetLeaderboardRankings(memberType, memberId, Language);
        }

        public Task<List<LeaderboardMemberRanking>> GetLeaderboardRankingsAsync(
            string memberType, string memberId, string language = null)
        {
            return LeaderboardsApi.GetLeaderboardRankingsAsync(memberType, memberId, language);
        }

        public List<Leaderboard> GetLeaderboards(int? currentPage = null, int? pageSize = null)
        {
            return LeaderboardsApi.GetLeaderboards(currentPage, pageSize, Language);
        }

        public Task<List<Leaderboard>> GetLeaderboardsAsync(int? currentPage = null,
            int? pageSize = null)
        {
            return LeaderboardsApi.GetLeaderboardsAsync(currentPage, pageSize, Language);
        }

        #endregion
    }

    static class ConfigurationExtension
    {
        public static Configuration Clone(this Configuration config, string token, string newBasePath)
        {
            return new Configuration(
                config.DefaultHeader,
                config.ApiKey,
                config.ApiKeyPrefix,
                newBasePath)
            { AccessToken = token };
        }
    }
}
