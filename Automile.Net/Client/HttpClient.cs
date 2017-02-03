using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    /// <summary>
    /// The core client to communicate with the Automile API
    /// </summary>
    public partial class AutomileClient
    {
        const string apiUrl = "https://api.automile.com";

        private HttpClient client;

        public TokenPair TokenPair { get; private set; }

        public string APIClient { get; private set; }

        public string APIClientSecret { get; private set; }
       
        /// <summary>
        /// Create a client from a username, password, client identifier and client secret
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="apiClient"></param>
        /// <param name="apiClientSecret"></param>
        /// <param name="writeAccess"></param>
        /// <param name="readAccess"></param>
        public AutomileClient(string username, string password, string apiClient, string apiClientSecret, bool writeAccess = true, bool readAccess = true)
        {
            APIClient = apiClient;
            APIClientSecret = apiClientSecret;

            #if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            #endif

            client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                AllowAutoRedirect = true,
                UseDefaultCredentials = false
            });
            client.Timeout = TimeSpan.FromSeconds(5);
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Automile.Net SDK");
            SetAPIClientAuthorizationHeader();

            List<string> scopes = new List<string>();
            if (readAccess == true)
                scopes.Add("read");
            if (writeAccess == true)
                scopes.Add("write");

            var formUrlContent = new Dictionary<string, string>
                        {
                            {"scope", string.Join(" ",scopes) },
                            {"username", username },
                            {"password", password },
                            {"grant_type", "password"}
                        };
            var content = new FormUrlEncodedContent(formUrlContent);
            var response = client.PostAsync("OAuth2/Token/", content).Result;

            response.EnsureSuccessStatusCode();

            TokenPair = JsonConvert.DeserializeObject<TokenPair>(response.Content.ReadAsStringAsync().Result);
            TokenPair.Expires = DateTime.UtcNow.AddSeconds(TokenPair.ExpiresIn);
    
            SetBearerTokenAuthorizationHeader();
        }

        private void SetAPIClientAuthorizationHeader()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                                  Convert.ToBase64String(
                                      System.Text.ASCIIEncoding.ASCII.GetBytes($"{APIClient}:{APIClientSecret}")));
        }

        private void SetBearerTokenAuthorizationHeader()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenPair.AccessToken);
        }

        private void RefreshAccessToken()
        {
            SetAPIClientAuthorizationHeader();

            var formUrlContent = new Dictionary<string, string>
                        {
                            {"refresh_token", TokenPair.RefreshToken },
                            {"grant_type", "refresh_token"}
                        };
            var content = new FormUrlEncodedContent(formUrlContent);
            var response = client.PostAsync("OAuth2/Token/", content).Result;

            response.EnsureSuccessStatusCode();

            TokenPair = JsonConvert.DeserializeObject<TokenPair>(response.Content.ReadAsStringAsync().Result);
            TokenPair.Expires = DateTime.UtcNow.AddSeconds(TokenPair.ExpiresIn);

            SetBearerTokenAuthorizationHeader();
        }

        
    }
}
