using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesCheckStatusResponse
    {
        [JsonProperty("service_status_desc")]
        public string Service_status { get; set; }
       
    }
}
