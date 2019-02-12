using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class UserCertificateConfigurations : IEntityTypeConfiguration<UserCertificate>
    {
        public void Configure(EntityTypeBuilder<UserCertificate> builder)
        {
           builder
               .HasKey(b => b.Id);

           builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

           builder
                .Property(b => b.URL)
                .IsRequired();

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            builder
                 .Property(b => b.CertificateId)
                 .IsRequired(false);

            //builder
            //     .HasOne<User>(uc => uc.User)
            //     .WithMany(u => u.UserCertificates)
            //     .HasForeignKey(uc => uc.UserId)
            //     .IsRequired();

            //builder
            //     .HasOne<Certificate>(uc => uc.Certificate)
            //     .WithMany(c => c.UserCertificates)
            //     .HasForeignKey(uc => uc.CertificateId)
            //     .IsRequired();
        }
    }
}
