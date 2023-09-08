using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class KeyVerificationTokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiryDate")]
        public string ExpiryDate { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
