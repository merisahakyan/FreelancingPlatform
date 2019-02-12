using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class EducationConfigurations : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.School)
                .IsRequired();

            builder
                .Property(b => b.DateFrom)
                .IsRequired();

            builder
                .Property(b => b.DateTo)
                .IsRequired();

            builder
                .Property(b => b.Degree)
                .IsRequired();

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            //builder
            //    .HasOne<User>(e => e.User)
            //    .WithMany(u => u.Educations)
            //    .HasForeignKey(e => e.UserId)
            //    .IsRequired();
        }
    }
}
