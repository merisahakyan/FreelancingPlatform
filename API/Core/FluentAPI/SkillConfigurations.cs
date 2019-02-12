using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FluentAPI
{
    public class SkillConfigurations : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
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
               .HasMany<UserSkill>(s => s.UserSkills)
               .WithOne(us => us.Skill)
               .HasForeignKey(u => u.SkillId);
        }
    }
}
