using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesRechargeResponse
    {
        [JsonProperty("basic_offer_display_name")]
        public string Basic_offer_display_name { get; set; }


        [JsonProperty("basic_offer_expiration_date")]
        public string Basic_offer_expiration_date { get; set; }



    }
}
