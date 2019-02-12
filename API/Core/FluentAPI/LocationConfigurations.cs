using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class LocationConfigurations : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Country)
                .IsRequired();

            builder
               .HasMany<User>(l => l.Users)
               .WithOne(u => u.Location)
               .HasForeignKey(u => u.LocationId);

            builder
               .HasMany<Employment>(l => l.Companies)
               .WithOne(e => e.Location)
               .HasForeignKey(e => e.LocationId);
        }
    }
}
