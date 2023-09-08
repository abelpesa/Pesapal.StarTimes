using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StarTimes.DAL.Entities;
using StarTimes.DAL.EntityCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTimes.DAL.Database
{
    public class StarTimesContext:DbContext
    {
        public StarTimesContext(DbContextOptions<StarTimesContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableForeignKey items in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {

                items.DeleteBehavior = DeleteBehavior.Restrict;

            }

            new NotificationDetailEntityTypeConfiguration().Configure(modelBuilder.Entity<NotificationDetail>());
            new SubscriberPaymentInfoEntityTypeConfiguration().Configure(modelBuilder.Entity<SubscriberPaymentInfo>());
            new SubscriberTransactionDetailEntityTypeConfiguration().Configure(modelBuilder.Entity<SubscriberTransactionDetail>());

            base.OnModelCreating(modelBuilder);


        }

        public override int SaveChanges()
        {
            DateTime currentDate = DateTime.UtcNow;

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entity)
                {

                    switch (item.State)
                    {

                        case EntityState.Modified:
                            Entry(entity).Property(a => a.ModifiedDate).IsModified = false;
                            entity.ModifiedDate = currentDate;
                            break;

                        case EntityState.Added:
                            entity.CreatedDate = currentDate;
                            entity.ModifiedDate = currentDate;
                            break;

                        default:
                            break;

                    }
                
                }
            
            
            }

            return base.SaveChanges();

        }


    }
}
