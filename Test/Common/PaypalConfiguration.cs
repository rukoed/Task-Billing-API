using System.Collections.Generic;
using PayPal.Api;

namespace Test.Common
{
    public  class PaypalConfiguration
    {
        // getting properties from the web.config
        public static Dictionary<string, string> GetConfig()
        {
            var result = ConfigManager.Instance.GetProperties();
            return result;
        }

        private static string GetAccessToken(string clientId, string clientSecret)
        {
            // getting access token from paypal                
            var accessToken = new OAuthTokenCredential(clientId.Replace(" ", string.Empty), clientSecret, GetConfig())
                .GetAccessToken();

            return accessToken;
        }

        public static APIContext GetAPIContext(string clientId, string clientSecret)
        {
            // return api context object by invoking it with the access token
            var apiContext = new APIContext(GetAccessToken(clientId, clientSecret)) {Config = GetConfig()};
            return apiContext;
        }
    }
}