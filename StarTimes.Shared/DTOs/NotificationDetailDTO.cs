using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.DTOs
{
    public class NotificationDetailDTO
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
