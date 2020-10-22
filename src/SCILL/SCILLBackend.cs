using System;
using SCILL.Api;
using SCILL.Client;
using SCILL.Model;

namespace SCILL
{
    public class SCILLBackend
    {
        public string ApiKey => Config.ApiKey[this.ToString()];
        public string UserId { get; private set; }

        public AuthApi AuthApi => _AuthApi.Value;
        public EventsApi EventsApi => _EventsApi.Value;
        
        private Lazy<AuthApi> _AuthApi;
        private Lazy<EventsApi> _EventsApi;

        private static Configuration Config;

        public SCILLBackend(string apiKey, string userId)
        {
            _EventsApi = new Lazy<EventsApi>(() => GetApi<EventsApi>(apiKey, "https://ep-dev.scillgame.com"), true);            
            _AuthApi = new Lazy<AuthApi>(() => GetApi<AuthApi>(apiKey, "https://us-dev.scillgame.com"), true);
            UserId = userId;
            
            Config = Configuration.Default.Clone(string.Empty, Configuration.Default.BasePath);
            Config.ApiKey[this.ToString()] = apiKey;
            
            // On backend side, the event parser is set to use the api key to authenticate the request
            Config.AddApiKey("auth", "api_key");
        }

        private string GetAccessToken(string userId)
        {
            return GetAccessToken(new ForeignUserIdentifier(userId));
        }

        private string GetAccessToken(ForeignUserIdentifier foreignUser)
        {
            if (string.IsNullOrEmpty(Config.AccessToken) == false)
                return Config.AccessToken;

            AccessToken access = AuthApi.GenerateAccessToken(foreignUser);

            return Config.AccessToken = access.token;
        }
        
        private T GetApi<T>(string token, string basePath) where T : IApiAccessor
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { Config.Clone(token, basePath) });
        }
    }
}