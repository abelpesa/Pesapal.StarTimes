using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class MerchantNotificationApiCreateRequest
    {
        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

    }
}
