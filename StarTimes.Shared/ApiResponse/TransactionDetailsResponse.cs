using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class TransactionDetailsResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("subscriberPaymentInfonId")]
        public int SubscriberPaymentInfonId { get; set; }
        [JsonProperty("confirmationCode")]
        public string ConfirmationCode { get; set; } 
        [JsonProperty("amount")]
        public decimal Amount { get; set; } 
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }
        [JsonProperty("trackingId")]
        public string TrackingId { get; set; }
        [JsonProperty("merchantReference")]
        public string MerchantReference { get; set; }
        [JsonProperty("posted")]
        public byte Posted { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
