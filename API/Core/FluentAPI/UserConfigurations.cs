using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                 .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Username)
                .IsRequired();

            builder
                .Property(b => b.Firstname)
                .IsRequired();

            builder
                .Property(b => b.Lastname)
                .IsRequired();

            builder
                .Property(b => b.Description)
                .IsRequired();

            builder
                .Property(b => b.DescriptionHeader)
                .IsRequired();

            builder
                .Property(b => b.HourlyRate)
                .IsRequired();

            builder
                .Property(b => b.TimePlusUTC)
                .IsRequired();

            builder
                .Property(b => b.Availability)
                .IsRequired();

            builder
                .Property(b => b.PasswordHash)
                .IsRequired();

            builder
                .Property(b => b.LocationId)
                .IsRequired(false);

            builder
                .Property(b => b.RoleId)
                .IsRequired(false);

            //builder
            //    .HasOne<Location>(u => u.Location)
            //    .WithMany(l => l.Users)
            //    .HasForeignKey(u => u.LocationId)
            //    .IsRequired();

            //builder
            //    .HasOne<Role>(u => u.Role)
            //    .WithMany(r => r.Users)
            //    .HasForeignKey(r => r.RoleId)
            //    .IsRequired();

            builder
              .HasMany<Work>(u => u.CreatedWorks)
              .WithOne(w => w.Creator)
              .HasForeignKey(w => w.CreatorId);

            builder
              .HasMany<UserWork>(uw => uw.UserWorks)
              .WithOne(uw => uw.User)
              .HasForeignKey(uw => uw.UserId);

            builder
              .HasMany<Feedback>(u => u.ReceivedFeedbacks)
              .WithOne(f => f.Receiver)
              .HasForeignKey(f => f.ReceiverId);

            builder
              .HasMany<Feedback>(u => u.GivingFeedbacks)
              .WithOne(f => f.Giving)
              .HasForeignKey(f => f.GivingId);

            builder
              .HasMany<Portfolio>(u => u.Portfolios)
              .WithOne(p => p.User)
              .HasForeignKey(p => p.UserId);

            builder
              .HasMany<Proposal>(u => u.Proposals)
              .WithOne(p => p.User)
              .HasForeignKey(p => p.UserId);

            builder
             .HasMany<UserSkill>(u => u.UserSkills)
             .WithOne(us => us.User)
             .HasForeignKey(us => us.UserId);

            builder
             .HasMany<UserCertificate>(u => u.UserCertificates)
             .WithOne(uc => uc.User)
             .HasForeignKey(uc => uc.UserId);

            builder
             .HasMany<Employment>(u => u.Employment)
             .WithOne(e => e.User)
             .HasForeignKey(e => e.UserId);

            builder
             .HasMany<Education>(u => u.Educations)
             .WithOne(e => e.User)
             .HasForeignKey(e => e.UserId);
        }
    }
}
