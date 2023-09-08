using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.Entities
{
    public class SubscriberTransactionDetail:BaseEntity
    {
        public int SubscriberPaymentInfonId { get; set; }
        public string ConfirmationCode { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public Guid TrackingId { get; set; }
        public string MerchantReference { get; set; }
        public byte Posted { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }


        public SubscriberPaymentInfo SubscriberPaymentInfo { get; set; }

    }
}
