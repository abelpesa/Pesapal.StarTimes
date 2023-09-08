using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class KeyVerificationTokenRequest
    {
        [JsonProperty("consumer_key")]
        public string ConsumerKey { get; set; }

        [JsonProperty("consumer_secret")]
        public string ConsumerSecret { get; set; }
    }
}
