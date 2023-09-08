using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
