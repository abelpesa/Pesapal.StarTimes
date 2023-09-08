using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class ApiIpnReceivedResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("orderMerchantReference")]
        public string OrderMerchantReference { get; set; }

        [JsonProperty("orderNotificationType")]
        public string OrderNotificationType { get; set; }
        [JsonProperty("orderTrackingId")]
        public string OrderTrackingId { get; set; }
    }
}
