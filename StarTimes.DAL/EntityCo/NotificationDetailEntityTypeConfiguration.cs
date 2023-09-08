using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.EntityCo
{
    public class NotificationDetailEntityTypeConfiguration : IEntityTypeConfiguration<NotificationDetail>
    {
        public void Configure(EntityTypeBuilder<NotificationDetail> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("NotificationDetails");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.UniqueId).HasMaxLength(256);

            builder.HasIndex(a => a.CreatedDate).HasName($"IX_{nameof(NotificationDetail)}_CreatedDate");
        }
    }
}
