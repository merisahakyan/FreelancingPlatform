using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    class CertificateConfigurations : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                   .IsRequired();


            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd();

            builder.HasMany<UserCertificate>(c => c.UserCertificates)
                   .WithOne(uc => uc.Certificate)
                   .HasForeignKey(uc => uc.CertificateId);
        }
    }
}
