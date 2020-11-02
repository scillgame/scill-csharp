using System;
using System.Threading.Tasks;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace SCILL
{
    public class SCILLBackend
    {
        public string ApiKey => Config.ApiKey[this.ToString()];

        public AuthApi AuthApi => _AuthApi.Value;
        public EventsApi EventsApi => _EventsApi.Value;
        
        private Lazy<AuthApi> _AuthApi;
        private Lazy<EventsApi> _EventsApi;

        private static Configuration Config;

        public SCILLBackend(string apiKey)
        {
            _EventsApi = new Lazy<EventsApi>(() => GetApi<EventsApi>(apiKey, "https://ep.scillgame.com"), true);            
            _AuthApi = new Lazy<AuthApi>(() => GetApi<AuthApi>(apiKey, "https://us.scillgame.com"), true);

            Config = Configuration.Default.Clone(string.Empty, Configuration.Default.BasePath);
            Config.ApiKey[this.ToString()] = apiKey;
            
            // On backend side, the event parser is set to use the api key to authenticate the request
            Config.AddApiKey("auth", "api_key");
        }

        public string GetAccessToken(string userId)
        {
            return GetAccessToken(new ForeignUserIdentifier(userId));
        }

        public Task<string> GetAccessTokenAsync(string userId)
        {
            return GetAccessTokenAsync(new ForeignUserIdentifier(userId));
        }

        private string GetAccessToken(ForeignUserIdentifier foreignUser)
        {
            if (string.IsNullOrEmpty(Config.AccessToken) == false)
                return Config.AccessToken;

            AccessToken access = AuthApi.GenerateAccessToken(foreignUser);

            return Config.AccessToken = access.token;
        }
        
        private async Task<string> GetAccessTokenAsync(ForeignUserIdentifier foreignUser)
        {
            if (string.IsNullOrEmpty(Config.AccessToken) == false)
                return Config.AccessToken;

            AccessToken access = await AuthApi.GenerateAccessTokenAsync(foreignUser);

            return Config.AccessToken = access.token;
        }
        
        private T GetApi<T>(string token, string basePath) where T : IApiAccessor
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { Config.Clone(token, basePath) });
        }
    }
}
