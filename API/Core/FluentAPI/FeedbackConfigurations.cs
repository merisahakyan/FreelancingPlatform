using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class FeedbackConfigurations : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder
               .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Message)
                .IsRequired();

            builder
                .Property(b => b.Rating)
                .IsRequired();

            builder
                .Property(b => b.GivingId)
                .IsRequired();

            builder
                 .Property(b => b.ReceiverId)
                 .IsRequired(false);

            builder
                  .Property(b => b.WorkId)
                  .IsRequired(false);


            //builder
            //    .HasOne<User>(f => f.Giving)
            //    .WithMany(u => u.GivingFeedbacks)
            //    .HasForeignKey(f => f.GivingId)
            //    .IsRequired();

            //builder
            //    .HasOne<User>(f => f.Receiver)
            //    .WithMany(u => u.ReceivedFeedbacks)
            //    .HasForeignKey(f => f.ReceiverId)
            //    .IsRequired();

            //builder
            //    .HasOne<Work>(f => f.Work)
            //    .WithMany(w => w.Feedbacks)
            //    .HasForeignKey(f => f.WorkId)
            //    .IsRequired();
        }
    }
}
