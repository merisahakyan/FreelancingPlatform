using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.UserId)
                .IsRequired(false);

            builder
                .Property(b => b.SkillId)
                .IsRequired(false);

            //builder
            //    .HasOne<User>(us => us.User)
            //    .WithMany(u => u.UserSkills)
            //    .HasForeignKey(us => us.UserId)
            //    .IsRequired();

            //builder
            //    .HasOne<Skill>(us => us.Skill)
            //    .WithMany(s => s.UserSkills)
            //    .HasForeignKey(us => us.SkillId)
            //    .IsRequired();
        }
    }
}
