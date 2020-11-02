using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace SCILL
{
    public class SCILLClient
    {
        public string AccessToken;
        public string AppId;
        
        public EventsApi EventsApi => _EventsApi.Value;
        public ChallengesApi ChallengesApi => _ChallengesApi.Value;
        public BattlePassesApi BattlePassesApi => _BattlePassesApi.Value;

        private Lazy<EventsApi> _EventsApi;
        private Lazy<ChallengesApi> _ChallengesApi;
        private Lazy<BattlePassesApi> _BattlePassesApi;

        private static Configuration Config;

        public SCILLClient(string accessToken, string appId)
        {
            AccessToken = accessToken;
            AppId = appId;

            _EventsApi = new Lazy<EventsApi>(() => GetApi<EventsApi>(AccessToken, "https://ep.scillgame.com"), true);
            _ChallengesApi = new Lazy<ChallengesApi>(() => GetApi<ChallengesApi>(AccessToken, "https://pcs.scillgame.com"), true);
            _BattlePassesApi = new Lazy<BattlePassesApi>(() => GetApi<BattlePassesApi>(AccessToken, "https://es.scillgame.com"), true);

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
        public ActionResponse ClaimBattlePassLevelReward(BattlePassLevelId body, string bpid)
        {
            return BattlePassesApi.ClaimBattlePassLevelReward(body, AppId, bpid);
        }

        public async Task<ActionResponse> ClaimBattlePassLevelRewardAsync(BattlePassLevelId body, string bpid)
        {
            return await BattlePassesApi.ClaimBattlePassLevelRewardAsync(body, AppId, bpid);
        }

        public BattlePass GetBattlePass(string bpid)
        {
            return BattlePassesApi.GetBattlePass(AppId, bpid);
        }

        public async Task<BattlePass> GetBattlePassAsync(string bpid)
        {
            return await BattlePassesApi.GetBattlePassAsync(AppId, bpid);
        }

        public List<BattlePass> GetBattlePass()
        {
            return BattlePassesApi.GetBattlePasses(AppId);
        }

        public async Task<List<BattlePass>> GetBattlePassesAsync()
        {
            return await BattlePassesApi.GetBattlePassesAsync(AppId);
        }

        public ActionResponse UnlockBattlePassLevel(BattlePassLevelId body, string bpid)
        {
            return BattlePassesApi.UnlockBattlePassLevel(body, AppId, bpid);
        }

        public async Task<ActionResponse> UnlockBattlePassLevelAsync(BattlePassLevelId body, string bpid)
        {
            return await BattlePassesApi.UnlockBattlePassLevelAsync(body, AppId, bpid);
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
