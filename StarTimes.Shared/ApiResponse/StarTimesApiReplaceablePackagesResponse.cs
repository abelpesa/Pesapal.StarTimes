using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesApiReplaceablePackagesResponse : BaseResponse
    {
        [JsonProperty("responses")]
        public List<StarTimesReplaceableItemResponse> Responses { get; set; }
    }
}
