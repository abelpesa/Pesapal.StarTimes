using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarTimes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.EntityCo
{
    public class SubscriberTransactionEntityTypeConfiguration : IEntityTypeConfiguration<SubscriberTransaction>
    {
        public void Configure(EntityTypeBuilder<SubscriberTransaction> builder)
        {

            builder.ToTable("SubscriberTransactions");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.PackageCode).HasMaxLength(50);
            builder.Property(a => a.Phone).HasMaxLength(20);
            builder.Property(a => a.ServiceCode).HasMaxLength(60);

            builder.HasIndex(a => a.CreatedDate).HasName($"IX_{nameof(SubscriberTransaction)}_CreatedDate");


        }
    }
}
