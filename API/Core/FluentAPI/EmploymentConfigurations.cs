using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class EmploymentConfigurations : IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> builder)
        {
            builder
               .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Company)
                .IsRequired();

            builder
                .Property(b => b.City)
                .IsRequired();

            builder
                .Property(b => b.Title)
                .IsRequired();

            builder
                .Property(b => b.Role)
                .IsRequired();

            builder
                .Property(b => b.DateFrom)
                .IsRequired();


            builder
                .Property(b => b.LocationId)
                .IsRequired(false);

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            //builder
            //    .HasOne<User>(e => e.User)
            //    .WithMany(u => u.Employment)
            //    .HasForeignKey(e => e.UserId);

            //builder
            //    .HasOne<Location>(e => e.Location)
            //    .WithMany(l => l.Companies)
            //    .HasForeignKey(e => e.LocationId)
            //    .IsRequired();
        }
    }
}
