using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class WorkKeyConfigurations : IEntityTypeConfiguration<WorkKey>
    {
        public void Configure(EntityTypeBuilder<WorkKey> builder)
        {
            builder
                            .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.WorkId)
                .IsRequired(false);

            builder
                .Property(b => b.KeyId)
                .IsRequired(false);

            //builder
            //    .HasOne<Key>(wk => wk.Key)
            //    .WithMany(k => k.WorkKeys)
            //    .HasForeignKey(wk => wk.KeyId)
            //    .IsRequired();

            //builder
            //    .HasOne<Work>(wk => wk.Work)
            //    .WithMany(w => w.WorkKeys)
            //    .HasForeignKey(wk => wk.WorkId)
            //    .IsRequired();
        }
    }
}
