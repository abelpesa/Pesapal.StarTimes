using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Pesapal.StarTimes.Portal.Models
{
    public class StarTimeRequest
    {
        [DisplayName("Service Code")]
        public string Service_code { get; set; }
        [DisplayName("Package")]
        public string New_package_code { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Amount { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
