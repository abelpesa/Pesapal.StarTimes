using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class StarTimesReplaceablePackageRequest
    {
        [JsonProperty("service_code")]
        public string Service_code { get; set; }


    }
}
