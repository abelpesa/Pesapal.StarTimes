using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class TransactionDetailListResponse : BaseResponse
    {
        [JsonProperty("transactionDetailsResponses")]
        public List<TransactionDetailsResponse> TransactionDetailsResponses { get; set; }

    }
}
