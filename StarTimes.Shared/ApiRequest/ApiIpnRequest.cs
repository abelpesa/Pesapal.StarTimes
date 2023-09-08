using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class ApiIpnRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("ipn_notification_type")]
        public string Ipn_notification_type { get; set; }
    }
}
