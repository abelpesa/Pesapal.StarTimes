using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pesapal.StarTimes.Model
{
    public class NotificationDTO
    {

            public int Id { get; set; }
            public string UniqueId { get; set; }

            public DateTime CreatedDate { get; set; }

            public DateTime? ModifiedDate { get; set; }
        
    }
}
