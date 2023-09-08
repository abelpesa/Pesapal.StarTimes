using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class PaymentQueryApiResponse
    {
        [JsonProperty("payment_method")]
        public string Payment_method { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("created_date")]
        public string Created_date { get; set; }

        [JsonProperty("confirmation_code")]
        public string Confirmation_code { get; set; }

        [JsonProperty("payment_status_description")]
        public string Payment_status_description { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("payment_account")]
        public string Payment_account { get; set; }

        [JsonProperty("call_back_url")]
        public string Call_back_url { get; set; }
        [JsonProperty("status_code")]
        public int Status_code { get; set; }
        [JsonProperty("merchant_reference")]
        public string Merchant_reference { get; set; }
        [JsonProperty("payment_status_code")]
        public string Payment_status_code { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public PaymentQueryApiErrorResponse Error { get; set; }
    }

    public class PaymentQueryApiErrorResponse
    {
        [JsonProperty("error_type")]
        public string Error_type { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; } 
        [JsonProperty("call_back_url")]
        public string Call_back_url { get; set; }

    }
}


