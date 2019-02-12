using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class UserWorkConfigurations : IEntityTypeConfiguration<UserWork>
    {
        public void Configure(EntityTypeBuilder<UserWork> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.TotalEarned)
                .IsRequired();

            builder
                .Property(b => b.UserRate)
                .IsRequired();

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            builder
                .Property(b => b.WorkId)
                .IsRequired(false);

            //builder
            //    .HasOne<User>(uw => uw.User)
            //    .WithMany(u => u.UserWorks)
            //    .HasForeignKey(uw => uw.UserId)
            //    .IsRequired();

            //builder
            //    .HasOne<Work>(uw => uw.Work)
            //    .WithMany(w => w.UserWorks)
            //    .HasForeignKey(uw => uw.WorkId)
            //    .IsRequired();
        }
    }
}
