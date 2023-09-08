using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pesapal.StarTimes.Model
{
    public class SubscriberPaymentInfoDTO
    {
        public int Id { get; set; }

        public string SubsciberId { get; set; }
        public string ServiceCode { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string ContactAddress { get; set; }
        public string SubscriberStatus { get; set; }
        public string ExpirationDate { get; set; }
        public string BasicOfferDisplayName { get; set; }
        public string BasicOfferBusinessClass { get; set; }
        public string OtherInfo { get; set; }
        public string Reference { get; set; }
        public string NewPackageCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Amount { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
