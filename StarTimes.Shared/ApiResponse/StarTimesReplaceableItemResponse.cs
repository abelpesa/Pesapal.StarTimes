using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
   public  class StarTimesReplaceableItemResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("display_name")]
        public string Display_name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
