using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class TransactionStatusInfoResponse
    {
        public string StatusUpdate { get; set; }
        public string Paymentmode { get; set; } 
        public string Paymentref { get; set; }
        public string Currency { get; set; }
        public string ConfirmationCode { get; set; }
        public string MerchantRef { get; set; }
        public decimal Amount { get; set; }
    }
}
