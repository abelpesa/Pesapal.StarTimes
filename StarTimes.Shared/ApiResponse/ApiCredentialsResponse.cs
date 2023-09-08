using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class ApiCredentialsResponse
    {
        [JsonProperty("consumer_key")]
        public string ConsumerKey { get; set; }
        [JsonProperty("consumer_secret")]
        public string ConsumerSecret { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
