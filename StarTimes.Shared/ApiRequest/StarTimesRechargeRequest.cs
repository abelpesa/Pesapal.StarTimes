using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class StarTimesRechargeRequest
    {
        [JsonProperty("serial_no")]
        public string Serial_no { get; set; }
        [JsonProperty("transaction_time")]
        public string Transaction_time { get; set; }
        [JsonProperty("service_code")]
        public string Service_code { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; } 
        [JsonProperty("new_package_code")]
        public string New_package_code { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }


    }
}
