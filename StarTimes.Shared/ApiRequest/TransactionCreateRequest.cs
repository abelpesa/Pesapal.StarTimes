using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class TransactionCreateRequest
    {
        [JsonProperty("orderMerchantReference")]
        public string OrderMerchantReference { get; set; }

        [JsonProperty("orderNotificationType")]
        public string OrderNotificationType { get; set; }
        [JsonProperty("orderTrackingId")]
        public string OrderTrackingId { get; set; }
    }
}
