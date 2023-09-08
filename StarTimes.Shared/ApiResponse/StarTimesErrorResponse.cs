using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesErrorResponse
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

    }
}
