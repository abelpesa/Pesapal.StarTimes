using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.EntityCo
{
    public class SubscriberPaymentInfoEntityTypeConfiguration : IEntityTypeConfiguration<SubscriberPaymentInfo>
    {
        public void Configure(EntityTypeBuilder<SubscriberPaymentInfo> builder)
        {
            builder.ToTable("SubscriberInfos");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ContactAddress).HasMaxLength(256);
            builder.Property(a => a.CustomerName).HasMaxLength(100);
            builder.Property(a => a.Mobile).HasMaxLength(20);
            builder.Property(a => a.OtherInfo).HasMaxLength(256);
            builder.Property(a => a.Reference).HasMaxLength(100);
            builder.Property(a => a.ServiceCode).HasMaxLength(100);
            builder.Property(a => a.SubsciberId).HasMaxLength(100);
            builder.Property(a => a.SubscriberStatus).HasMaxLength(60);
            builder.Property(a => a.NewPackageCode).HasMaxLength(60);
            builder.Property(a => a.Firstname).HasMaxLength(60);
            builder.Property(a => a.Lastname).HasMaxLength(60);
            builder.Property(a => a.Amount).HasColumnType("decimal(18,2)");
            builder.Property(a => a.MobileNumber).HasMaxLength(15);
            builder.Property(a => a.Email).HasMaxLength(100);

            builder.HasIndex(a => a.CreatedDate).HasName($"IX_{nameof(SubscriberPaymentInfo)}_CreatedDate");
            builder.HasIndex(a => a.Reference).HasName($"IX_{nameof(SubscriberPaymentInfo)}_Reference");
            builder.HasIndex(a => a.ServiceCode).HasName($"IX_{nameof(SubscriberPaymentInfo)}_ServiceCode");

        }
    }
}
