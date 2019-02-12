using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class KeyConfigurations : IEntityTypeConfiguration<Key>
    {
        public void Configure(EntityTypeBuilder<Key> builder)
        {

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Name)
                .IsRequired();

            builder
               .HasMany<WorkKey>(k => k.WorkKeys)
               .WithOne(wk => wk.Key)
               .HasForeignKey(wk => wk.KeyId);
        }
    }
}
