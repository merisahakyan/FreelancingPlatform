using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class ProposalConfigurations : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder
                  .Property(b => b.Id)
                  .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Date)
                .IsRequired();

            builder
                .Property(b => b.DaysCount)
                .IsRequired();

            builder
                .Property(b => b.Rate)
                .IsRequired();

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            builder
                .Property(b => b.WorkId)
                .IsRequired(false);

            //builder
            //    .HasOne<User>(uw => uw.User)
            //    .WithMany(u => u.Proposals)
            //    .HasForeignKey(uw => uw.UserId)
            //    .IsRequired();

            //builder
            //    .HasOne<Work>(uw => uw.Work)
            //    .WithMany(w => w.Proposals)
            //    .HasForeignKey(uw => uw.WorkId)
            //    .IsRequired();

        }
    }
}
