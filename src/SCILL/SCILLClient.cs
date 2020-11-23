using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public EventsApi EventsApi => _EventsApi.Value;
        public ChallengesApi ChallengesApi => _ChallengesApi.Value;
        public BattlePassesApi BattlePassesApi => _BattlePassesApi.Value;

        private Lazy<EventsApi> _EventsApi;
        private Lazy<ChallengesApi> _ChallengesApi;
        private Lazy<BattlePassesApi> _BattlePassesApi;

        private static Configuration Config;

        public SCILLClient(string accessToken, string appId, Environment environment = Environment.Production)
        {
            AccessToken = accessToken;
            AppId = appId;

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

            Config = Configuration.Default.Clone(string.Empty, Configuration.Default.BasePath);
            Config.ApiKey[this.ToString()] = AccessToken;
            
            // On client side, the event parser is set to use the access token to authenticate the request
            Config.AddApiKey("auth", "access_token");
        }
        
        private T GetApi<T>(string token, string basePath) where T : IApiAccessor
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { Config.Clone(token, basePath) });
        }
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

        public List<ChallengeCategory> GetPersonalChallenges()
        {
            return ChallengesApi.GetPersonalChallenges(AppId);
        }

        public async Task<List<ChallengeCategory>> GetPersonalChallengesAsync()
        {
            return await ChallengesApi.GetPersonalChallengesAsync(AppId);
        }
        
        public Challenge GetPersonalChallengeById(string challengeId)
        {
            return ChallengesApi.GetPersonalChallengeById(AppId, challengeId);
        }

        public async Task<Challenge> GetPersonalChallengeByIdAsync(string challengeId)
        {
            return await ChallengesApi.GetPersonalChallengeByIdAsync(AppId, challengeId);
        }

        public List<ChallengeCategory> GetActivePersonalChallenges()
        {
            return ChallengesApi.GetActivePersonalChallenges(AppId);
        }

        public async Task<List<ChallengeCategory>> GetActivePersonalChallengesAsync()
        {
            return await ChallengesApi.GetActivePersonalChallengesAsync(AppId);
        }

        public ActionResponse UnlockPersonalChallenge(string challengeId)
        {
            return ChallengesApi.UnlockPersonalChallenge(AppId, challengeId);
        }

        public async Task<ActionResponse> UnlockPersonalChallengeAsync(string challengeId)
        {
            return await ChallengesApi.UnlockPersonalChallengeAsync(AppId, challengeId);
        }
        #endregion ChallengesApi
        
        #region BattlePassesApi

        public ActionResponse ActivateBattlePassLevel(string levelId)
        {
            return BattlePassesApi.ActivateBattlePassLevel(AppId, levelId);
        }
        
        public async Task<ActionResponse> ActivateBattlePassLevelAsync(string levelId)
        {
            return await BattlePassesApi.ActivateBattlePassLevelAsync(AppId, levelId);
        }

        public ActionResponse ClaimBattlePassLevelReward(string levelId)
        {
            return BattlePassesApi.ClaimBattlePassLevelReward(AppId, levelId);
        }

        public async Task<ActionResponse> ClaimBattlePassLevelRewardAsync(string levelId)
        {
            return await BattlePassesApi.ClaimBattlePassLevelRewardAsync(AppId, levelId);
        }

        public List<BattlePass> GetActiveBattlePasses()
        {
            return BattlePassesApi.GetActiveBattlePasses(AppId);
        }

        public async Task<List<BattlePass>> GetActiveBattlePassesAsync()
        {
            return await BattlePassesApi.GetActiveBattlePassesAsync(AppId);
        }

        public List<BattlePassLevel> GetAllBattlePassLevels()
        {
            return BattlePassesApi.GetAllBattlePassLevels(AppId);
        }
        
        public async Task<List<BattlePassLevel>> GetAllBattlePassLevelsAsync()
        {
            return await BattlePassesApi.GetAllBattlePassLevelsAsync(AppId);
        }

        public BattlePass GetBattlePass(string battlePassId)
        {
            return BattlePassesApi.GetBattlePass(AppId, battlePassId);
        }

        public async Task<BattlePass> GetBattlePassAsync(string battlePassId)
        {
            return await BattlePassesApi.GetBattlePassAsync(AppId, battlePassId);
        }
        
        public List<BattlePassLevel> GetBattlePassLevels(string battlePassId)
        {
            return BattlePassesApi.GetBattlePassLevels(AppId, battlePassId);
        }
        
        public async Task<List<BattlePassLevel>> GetBattlePassLevelsAsync(string battlePassId)
        {
            return await BattlePassesApi.GetBattlePassLevelsAsync(AppId, battlePassId);
        }

        public List<BattlePass> GetBattlePasses()
        {
            return BattlePassesApi.GetBattlePasses(AppId);
        }
        
        public async Task<List<BattlePass>> GetBattlePassesAsync()
        {
            return await BattlePassesApi.GetBattlePassesAsync(AppId);
        }

        public List<BattlePass> GetUnlockedBattlePasses()
        {
            return BattlePassesApi.GetUnlockedBattlePasses(AppId);
        }
        
        public async Task<List<BattlePass>> GetUnlockedBattlePassesAsync()
        {
            return await BattlePassesApi.GetUnlockedBattlePassesAsync(AppId);
        }

        public BattlePassUnlockInfo UnlockBattlePass(string battlePassId,
            BattlePassUnlockPayload body = null)
        {
            return BattlePassesApi.UnlockBattlePass(AppId, battlePassId, body);
        }
        
        public async Task<BattlePassUnlockInfo> UnlockBattlePassAsync(string battlePassId,
            BattlePassUnlockPayload body = null)
        {
            return await BattlePassesApi.UnlockBattlePassAsync(AppId, battlePassId, body);
        }
        
        #endregion BattlePassesApi
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
