using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

       // const string apiUrl = "https://localhost:44302/";

        private HttpClient client;

        public TokenPair TokenPair { get; private set; }

        public string APIClient { get; private set; }

        public string APIClientSecret { get; private set; }
       

        public static SignUpResponseModel SignUp(string email)
        {
            HttpClient signupClient = new HttpClient();
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
            
            signupClient = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                AllowAutoRedirect = true,
                UseDefaultCredentials = false
            });
            signupClient.Timeout = TimeSpan.FromSeconds(15);
            signupClient.BaseAddress = new Uri(apiUrl);
            signupClient.DefaultRequestHeaders.Accept.Clear();
            signupClient.DefaultRequestHeaders.Add("User-Agent", "Automile.Net SDK");

            SignUpRequestModel requestModel = new SignUpRequestModel();
            requestModel.Email = email;
            
            string stringPayload = JsonConvert.SerializeObject(requestModel);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = signupClient.PostAsync($"/signup", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<SignUpResponseModel>(response.Content.ReadAsStringAsync().Result);
        }

        private AutomileClient()
        {

#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif

            client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                AllowAutoRedirect = true,
                UseDefaultCredentials = false
            });
            client.Timeout = TimeSpan.FromSeconds(15);
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Automile.Net SDK");
        }

        /// <summary>
        /// Create a client from a username, password, client identifier and client secret
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="apiClient"></param>
        /// <param name="apiClientSecret"></param>
        /// <param name="writeAccess"></param>
        /// <param name="readAccess"></param>
        public AutomileClient(string username, string password, string apiClient, string apiClientSecret, bool writeAccess = true, bool readAccess = true) : this()
        {
            APIClient = apiClient;
            APIClientSecret = apiClientSecret;
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

            response.EnsureSuccessStatusCodeWithProperExceptionMessage();

            TokenPair = JsonConvert.DeserializeObject<TokenPair>(response.Content.ReadAsStringAsync().Result);
            TokenPair.Expires = DateTime.UtcNow.AddSeconds(TokenPair.ExpiresIn);


            Debug.WriteLine(JsonConvert.SerializeObject(TokenPair));
    
            SetBearerTokenAuthorizationHeader();
        }

        /// <summary>
        /// Create client from a saved bearer token
        /// </summary>
        /// <param name="token"></param>
        public AutomileClient(TokenPair token) : this()
        {
            TokenPair = token;
            SetBearerTokenAuthorizationHeader();
        }

        /// <summary>
        /// Create the client from a saved token in the file system
        /// </summary>
        /// <param name="pathToTokenFile"></param>
        public AutomileClient(string pathToTokenFile) : this()
        {
            string tokenJson = System.IO.File.ReadAllText(pathToTokenFile);
            TokenPair = JsonConvert.DeserializeObject<TokenPair>(tokenJson);
            SetBearerTokenAuthorizationHeader();
        }

        /// <summary>
        /// Create client from a signup response
        /// </summary>
        /// <param name="signUpResponse"></param>
        public AutomileClient(SignUpResponseModel signUpResponse) : this(signUpResponse.Username, signUpResponse.Password, signUpResponse.APIClientIdentifier, signUpResponse.APIClientSecret)
        {
        }

        /// <summary>
        /// Save the token to a file
        /// </summary>
        /// <param name="path"></param>
        public void SaveToken(string path)
        {
            string tokenJson = JsonConvert.SerializeObject(TokenPair);
            System.IO.File.WriteAllText(path, tokenJson);
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

            response.EnsureSuccessStatusCodeWithProperExceptionMessage();

            TokenPair = JsonConvert.DeserializeObject<TokenPair>(response.Content.ReadAsStringAsync().Result);
            TokenPair.Expires = DateTime.UtcNow.AddSeconds(TokenPair.ExpiresIn);

            SetBearerTokenAuthorizationHeader();
        }

        
    }
}
