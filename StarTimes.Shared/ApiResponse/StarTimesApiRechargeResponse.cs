using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesApiRechargeResponse : BaseResponse
    {
        [JsonProperty("paymentUrl")]
        public string PaymentUrl { get; set; }

    }
}
