using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.EntityCo
{
   public class SubscriberTransactionDetailEntityTypeConfiguration : IEntityTypeConfiguration<SubscriberTransactionDetail>
    {
        public void Configure(EntityTypeBuilder<SubscriberTransactionDetail> builder)
        {
            builder.ToTable("SubscriberTransactionDetails");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.MerchantReference).HasMaxLength(256);
            builder.Property(a => a.PaymentMethod).HasMaxLength(256);
            builder.Property(a => a.Status).HasMaxLength(256);
            builder.Property(a => a.TrackingId).HasMaxLength(256);
            builder.Property(a => a.Amount).HasColumnType("decimal(18,2)");
            builder.Property(a => a.Currency).HasMaxLength(3);
            builder.Property(a => a.Posted).HasMaxLength(3);
            builder.Property(a => a.ConfirmationCode).HasMaxLength(50);

            builder.HasIndex(a => a.CreatedDate).HasName($"IX_{nameof(SubscriberTransactionDetail)}_CreatedDate");
            builder.HasOne(a => a.SubscriberPaymentInfo).WithMany().HasForeignKey(a => a.SubscriberPaymentInfonId).OnDelete(DeleteBehavior.Restrict).IsRequired();

        }
    }
}
