using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.BLL.DTO
{
    public class SubscriberTransactionDetailDTO
    {
        public int Id { get; set; }

        public int SubscriberPaymentInfonId { get; set; }
        public string ConfirmationCode { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public Guid TrackingId { get; set; }
        public string MerchantReference { get; set; }
        public byte Posted { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
