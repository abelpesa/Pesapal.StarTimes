using Microsoft.Extensions.Configuration;
using RestSharp;
using StarTimes.Shared.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesapal.StarTimes.Portal.Utility
{
    public class Utility
    {
        public static IRestResponse PostApiData(string data, string resourceUrl, int requestType, RestRequest restRequest = null)
        {

            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var apiUrl = root.GetSection("Basehosting:apiurl");

            string baseurl = apiUrl.Value;
            IRestRequest request = new RestRequest();


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
