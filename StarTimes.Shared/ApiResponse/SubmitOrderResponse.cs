using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class SubmitOrderResponse
    {
        [JsonProperty("order_tracking_id")]
        public string Order_tracking_id { get; set; }
        [JsonProperty("merchant_reference")]
        public string Merchant_reference { get; set; }


        [JsonProperty("redirect_url")]
        public string Redirect_url { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
