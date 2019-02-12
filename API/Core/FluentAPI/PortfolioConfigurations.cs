using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class PortfolioConfigurations : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {

            builder
                 .HasKey(b => b.Id);

            builder
                 .Property(b => b.Id)
                 .ValueGeneratedOnAdd();

            builder
                 .Property(b => b.Title)
                 .IsRequired();

            builder
                 .Property(b => b.Description)
                 .IsRequired();

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            //builder
            //     .HasOne<User>(p => p.User)
            //     .WithMany(u => u.Portfolios)
            //     .HasForeignKey(p => p.UserId)
            //     .IsRequired();
        }
    }
}
