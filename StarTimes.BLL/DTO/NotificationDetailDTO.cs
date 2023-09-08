using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.BLL.DTO
{
   public  class NotificationDetailDTO
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
