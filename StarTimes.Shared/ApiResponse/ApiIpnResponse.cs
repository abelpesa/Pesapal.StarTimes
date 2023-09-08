using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class ApiIpnResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_date")]
        public string Created_date { get; set; }

        [JsonProperty("ipn_id")]
        public string Ipn_id { get; set; }
        [JsonProperty("error")]
        public Errordetails Error { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("notification_type")]
        public int? Notification_type { get; set; }
        [JsonProperty("ipn_notification_type_description")]
        public string? Ipn_notification_type_description { get; set; }
        [JsonProperty("ipn_status")]
        public int? Ipn_status { get; set; }
        [JsonProperty("ipn_status_decription")]
        public string? Ipn_status_decription { get; set; }

    }
    public class Errordetails
    {
        [JsonProperty("error_type")]
        public string? Error_type { get; set; }
        [JsonProperty("code")]
        public string? Code { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("call_back_url")]
        public string? Call_back_url { get; set; }
    }

}
