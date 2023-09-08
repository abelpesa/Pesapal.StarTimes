using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class StarTimesCheckStatusRequest
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }
}
