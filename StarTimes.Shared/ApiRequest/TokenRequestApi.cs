using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class TokenRequestApi
    {
        [JsonProperty("consumer_key")]
        public string consumer_key { get; set; }

        [JsonProperty("consumer_secret")]
        public string consumer_secret { get; set; }
    }
}
