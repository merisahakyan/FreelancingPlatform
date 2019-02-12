using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class WorkConfigurations : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Description)
                .IsRequired();

            builder
                .Property(b => b.CreatorId)
                .IsRequired(false);

            //builder
            //    .HasOne<User>(w => w.Creator)
            //    .WithMany(u => u.CreatedWorks)
            //    .HasForeignKey(w => w.CreatorId)
            //    .IsRequired();

            builder
              .HasMany<UserWork>(w => w.UserWorks)
              .WithOne(uw => uw.Work)
              .HasForeignKey(uw => uw.WorkId);

            builder
             .HasMany<WorkKey>(w => w.WorkKeys)
             .WithOne(wk => wk.Work)
             .HasForeignKey(wk => wk.WorkId);

            builder
             .HasMany<Feedback>(w => w.Feedbacks)
             .WithOne(f => f.Work)
             .HasForeignKey(f => f.WorkId);

            builder
              .HasMany<Proposal>(u => u.Proposals)
              .WithOne(p => p.Work)
              .HasForeignKey(p => p.WorkId);
        }
    }
}
