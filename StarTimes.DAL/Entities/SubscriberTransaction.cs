using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.Entities
{
    public class SubscriberTransaction : BaseEntity
    {
        public string ServiceCode { get; set; }
        public decimal? Amount { get; set; }

        public string PackageCode { get; set; }
        public string Phone { get; set; }


    }
}
