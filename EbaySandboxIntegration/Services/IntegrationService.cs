using EbaySandboxIntegration.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EbaySandboxIntegration.Services
{

    public class IntegrationService
    {
        private static HttpClient httpClient = new HttpClient();
        private string token = "";
        

        public IntegrationService()
        {
           // httpClient.BaseAddress = new Uri("https://api.sandbox.ebay.com/");
            httpClient.Timeout = new TimeSpan(0, 0, 3);
        }

        public async Task  GetToken()
        {
            //cred
            var clientId = "Krystian-testDemo-SBX-dbcdef085-a5b59954";
            var clientSecret = "SBX-bcdef085ddea-bd1a-4437-80e0-ee08";
            var credentials = $"{clientId}:{clientSecret}";
            var credentialsByte = System.Text.Encoding.UTF8.GetBytes(credentials);
            var credentialsB64 = System.Convert.ToBase64String(credentialsByte);

            //body
            var scope = "https://api.ebay.com/oauth/api_scope";

            var contentList = new List<KeyValuePair<string, string>>();
            contentList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            contentList.Add(new KeyValuePair<string, string>("scope", HttpUtility.UrlEncode(scope)));

            var req = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.ebay.com/identity/v1/oauth2/token");
            req.Content = new FormUrlEncodedContent(contentList);

            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{credentialsB64}");
            //req.Headers.Add("Authorization", $"Basic {credentialsB64}");

            var response = await httpClient.SendAsync(req);

            var one = 1;
              
            //defaultowy header ustawić potem!!
            //httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {credentialsB64}");
            //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        }

        public async Task GetTokenRSharp()
        {
            //cred
            var clientId = "Krystian-testDemo-SBX-dbcdef085-a5b59954";
            var clientSecret = "SBX-bcdef085ddea-bd1a-4437-80e0-ee08";
            var credentials = $"{clientId}:{clientSecret}";
            var credentialsByte = System.Text.Encoding.UTF8.GetBytes(credentials);
            var credentialsB64 = System.Convert.ToBase64String(credentialsByte);

            //body
            var scope = "https://api.ebay.com/oauth/api_scope";

            var contentDict = new Dictionary<string, string>();
            contentDict.Add("grant_type", "client_credentials");
            contentDict.Add("scope", HttpUtility.UrlEncode(scope));


            var client = new RestClient("https://api.sandbox.ebay.com/identity/v1/oauth2/token");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", $"Basic {credentialsB64}");

            request.AddParameter("application/x-www-form-urlencoded", CreateRequestPayload(contentDict), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            OAuthApiResponse apiResponse = JsonConvert.DeserializeObject<OAuthApiResponse>(response.Content);
            token = apiResponse.AccessToken;

        }


        public async Task EmptySearch()
        {
            var client = new RestClient("https://api.sandbox.ebay.com/item_summary/search?");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Accept", "application/json");

            var  response = await client.ExecuteAsync(request);
            
        }

        public static String CreateRequestPayload(Dictionary<String, String> payloadParams)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<String, String> entry in payloadParams)
            {
                if (sb.Length > 0)
                {
                    sb.Append('&');
                }
                sb.Append(entry.Key).Append('=').Append(entry.Value);

            }
            return sb.ToString();
        }




    }
}
