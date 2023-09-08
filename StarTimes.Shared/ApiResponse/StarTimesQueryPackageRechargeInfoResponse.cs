using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesQueryPackageRechargeInfoResponse
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }


        [JsonProperty("display_name")]
        public string Display_name { get; set; }


        [JsonProperty("description")]
        public string Description { get; set; }



    }
}
