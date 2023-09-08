using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class ApiIpnListResponse
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("url")]
        public string? Url { get; set; }
        [JsonProperty("created_date")]
        public string? Created_date { get; set; }
        [JsonProperty("ipn_id")]
        public string? Ipn_id { get; set; }
        [JsonProperty("notification_type")]
        public int? Notification_type { get; set; }
        [JsonProperty("ipn_notification_type_description")]
        public string? Ipn_notification_type_description { get; set; }
        [JsonProperty("ipn_status")]
        public int? Ipn_status { get; set; }
        [JsonProperty("ipn_status_decription")]
        public string? Ipn_status_decription { get; set; }
        [JsonProperty("error")]
        public string? Error { get; set; }
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
