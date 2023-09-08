using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using StarTimes.Shared.ApiRequest;
using StarTimes.Shared.ApiResponse;
using StarTimes.Shared.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesapal.StarTimes.Utility
{
    public class Utility
    {
        public static string RequestConsumerKeysValidationToken()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var api3requesttoken = root.GetSection("Basehosting:api3requesttoken");
            var api3AppConsumerKey = root.GetSection("Basehosting:api3consumer_key");
            var api3AppConsumerSecret = root.GetSection("Basehosting:api3consumer_secret");

            KeyVerificationTokenRequest keyVerificationTokenRequest = new KeyVerificationTokenRequest();
            keyVerificationTokenRequest.ConsumerKey = api3AppConsumerKey.Value;
            keyVerificationTokenRequest.ConsumerSecret = api3AppConsumerSecret.Value;

            string data = JsonConvert.SerializeObject(keyVerificationTokenRequest);
            string resourceUrl = api3requesttoken.Value;
            string postResponse = PostApiDirect(data, resourceUrl, (int)HttpRequestMethods.POST);
            KeyVerificationTokenResponse keyVerificationTokenResponse = JsonConvert.DeserializeObject<KeyVerificationTokenResponse>(postResponse);

            if (keyVerificationTokenResponse.Status.Equals("200"))
            {
                return keyVerificationTokenResponse.Token;
            }
            return "";


        }
        public static ApiCredentialsResponse RequestConsumerKeys()
        {

            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var apiKeysCredentials = root.GetSection("Basehosting:api3keyscredentials");
            var envTestCheck = root.GetSection("Env:IsProduction");
            var envTestUserId = root.GetSection("Env:TestUserId");

            string token = RequestConsumerKeysValidationToken();
            string data = string.Empty;


            // string resourceUrl = apiKeysCredentials.Value + "userId=" + userId;

            string resourceUrl = apiKeysCredentials.Value + "userId=" + envTestUserId.Value;

            bool envCheck = Convert.ToBoolean(envTestCheck.Value);

            //if (!envCheck)
            //{
            //    resourceUrl = apiKeysCredentials.Value + "userId=" + envTestUserId.Value;
            //}

            string response = Utility.PostApiDataAPI3(data, resourceUrl, (int)HttpRequestMethods.GET, token);
            ApiCredentialsResponse apiCredentialsResponse = JsonConvert.DeserializeObject<ApiCredentialsResponse>(response);

            return apiCredentialsResponse;

        }
        public static string RequestApiToken(string key, string pass)
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var api3RequestToken = root.GetSection("Basehosting:api3requesttoken");



            TokenRequestApi tokenRequestApi = new TokenRequestApi();
            tokenRequestApi.consumer_key = key;
            tokenRequestApi.consumer_secret = pass;


            string data = JsonConvert.SerializeObject(tokenRequestApi);
            string resourceUrl = api3RequestToken.Value;
            string postResponse = PostApiDirect(data, resourceUrl, (int)HttpRequestMethods.POST);

            TokenResponse tokenResponseInfo = JsonConvert.DeserializeObject<TokenResponse>(postResponse);

            if (tokenResponseInfo.Status.Equals(200))
            {
                return tokenResponseInfo.Token;
            }
            return "";
        }
        public static string PostApiDirect(string data, string resourceUrl, int requestType, string token = "")
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var api3baseurl = root.GetSection("Basehosting:api3baseurl");


            string baseurl = api3baseurl.Value;
            IRestRequest request = new RestRequest();
            RestClient restClient = new RestClient { BaseUrl = new Uri(baseurl) };

            switch (requestType)
            {
                case (int)HttpRequestMethods.GET:
                    request = new RestRequest(resourceUrl);
                    request.Method = Method.GET;
                    break;

                case (int)HttpRequestMethods.POST:

                    restClient = new RestClient { BaseUrl = new Uri(baseurl) };
                    request = new RestRequest(resourceUrl);

                    if (!string.IsNullOrEmpty(token))
                    {
                        request.AddParameter("Authorization", string.Format("Bearer {0}", token), ParameterType.HttpHeader);
                    }

                    request.Method = Method.POST;
                    request.AddHeader("Accept", "application/json");
                    request.Parameters.Clear();
                    request.AddParameter("application/json", data, data, ParameterType.RequestBody);
                    break;
            }

            IRestResponse restResponse = restClient.Execute(request);
            if (restResponse != null)
            {

                return restResponse.Content;
            }
            return "";
        }
        public static string PostApiDataAPI3(string data, string resourceUrl, int requestType, string token, RestRequest restRequest = null)
        {

            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var api3requesttoken = root.GetSection("Basehosting:api3requesttoken");

            if (string.IsNullOrEmpty(token))
            {

                return "";

            }

            string baseurl = root.GetSection("Basehosting:api3baseurl").Value;
            IRestRequest request = new RestRequest();
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            RestClient restClient = new RestClient { BaseUrl = new Uri(baseurl) };

            switch (requestType)
            {
                case (int)HttpRequestMethods.GET:
                    if (restRequest != null)
                    {
                        request = restRequest;
                    }
                    else
                    {
                        request = new RestRequest(resourceUrl);
                    }

                    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                    request.Method = Method.GET;

                    if (!string.IsNullOrEmpty(data))
                    {

                    }

                    break;

                case (int)HttpRequestMethods.POST:
                    restClient = new RestClient { BaseUrl = new Uri(baseurl) };

                    request = new RestRequest(resourceUrl);
                    request.Method = Method.POST;
                    request.AddHeader("Accept", "application/json");
                    request.Parameters.Clear();
                    request.AddParameter("application/json", data, data, ParameterType.RequestBody);
                    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                    break;
            }

            IRestResponse restResponse = restClient.Execute(request);
            if (restResponse != null)
            {

                return restResponse.Content;

            }

            return "";
        }
        public static string PostApi3Data(string data, string resourceUrl, int requestType, string token, RestRequest restRequest = null)
        {


            if (string.IsNullOrEmpty(token))
            {

                return "";

            }
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var api3baseurl = root.GetSection("Basehosting:api3baseurl");


            string baseurl = api3baseurl.Value;

            IRestRequest request = new RestRequest();
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            RestClient restClient = new RestClient { BaseUrl = new Uri(baseurl) };

            switch (requestType)
            {
                case (int)HttpRequestMethods.GET:
                    if (restRequest != null)
                    {
                        request = restRequest;
                    }
                    else
                    {
                        request = new RestRequest(resourceUrl);
                    }

                    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                    request.Method = Method.GET;

                    if (!string.IsNullOrEmpty(data))
                    {

                    }

                    break;

                case (int)HttpRequestMethods.POST:
                    restClient = new RestClient { BaseUrl = new Uri(baseurl) };

                    request = new RestRequest(resourceUrl);
                    request.Method = Method.POST;
                    request.AddHeader("Accept", "application/json");
                    request.Parameters.Clear();
                    request.AddParameter("application/json", data, data, ParameterType.RequestBody);
                    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                    break;
            }

            IRestResponse restResponse = restClient.Execute(request);
            if (restResponse != null)
            {


                return restResponse.Content;

            }

            return "";
        }

        public static IRestResponse PostApiData(string data, string resourceUrl, int requestType, RestRequest restRequest = null)
        {


            string baseurl = "https://staging.stariboss.com/api-payment-service/v1/";
            IRestRequest request = new RestRequest();

            string username = "5160002@TZ.D";
            string password = "hs1BMPKf";

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{password}"));

            request.AddHeader("Authorization", string.Format("Basic {0}", encoded));

            RestClient restClient = new RestClient { BaseUrl = new Uri(baseurl) };

            switch (requestType)
            {
                case (int)HttpRequestMethods.GET:
                    if (restRequest != null)
                    {
                        request = restRequest;
                    }
                    else
                    {
                        request = new RestRequest(resourceUrl);
                    }

                    request.AddHeader("Authorization", string.Format("Basic {0}", encoded));
                    request.Method = Method.GET;

                    if (!string.IsNullOrEmpty(data))
                    {

                    }

                    break;

                case (int)HttpRequestMethods.POST:
                    restClient = new RestClient { BaseUrl = new Uri(baseurl) };

                    request = new RestRequest(resourceUrl);
                    request.Method = Method.POST;
                    request.AddHeader("Accept", "application/json");
                    request.Parameters.Clear();
                    request.AddParameter("application/json", data, data, ParameterType.RequestBody);
                    request.AddHeader("Authorization", string.Format("Basic {0}", encoded));
                    break;
            }

            IRestResponse restResponse = restClient.Execute(request);
            if (restResponse != null)
            {
                
                return restResponse;

            }

            return restResponse;
        }



    }
}
