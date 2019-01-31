using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Core.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCertificate> UserCertificates { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserWork> UserWorks { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkKey> WorkKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Certificate>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Certificate>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Certificate>()
                .HasMany<UserCertificate>(c => c.UserCertificates)
                .WithOne(uc => uc.Certificate)
                .HasForeignKey(uc => uc.CertificateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Education>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Education>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Education>()
                .Property(b => b.School)
                .IsRequired();

            modelBuilder.Entity<Education>()
                .Property(b => b.DateFrom)
                .IsRequired();

            modelBuilder.Entity<Education>()
                .Property(b => b.DateTo)
                .IsRequired();

            modelBuilder.Entity<Education>()
                .Property(b => b.Degree)
                .IsRequired();

            modelBuilder.Entity<Education>()
                .HasOne<User>(e => e.User)
                .WithMany(u => u.Educations)
                .HasForeignKey(e => e.UserId)
                .IsRequired();


            modelBuilder.Entity<Employment>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Employment>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employment>()
                .Property(b => b.Company)
                .IsRequired();

            modelBuilder.Entity<Employment>()
                .Property(b => b.City)
                .IsRequired();

            modelBuilder.Entity<Employment>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Employment>()
                .Property(b => b.Role)
                .IsRequired();

            modelBuilder.Entity<Employment>()
                .Property(b => b.DateFrom)
                .IsRequired();


            modelBuilder.Entity<Employment>()
                .Property(b => b.LocationId)
                .IsRequired();

            modelBuilder.Entity<Employment>()
                .HasOne<User>(e => e.User)
                .WithMany(u => u.Employment)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Employment>()
                .HasOne<Location>(e => e.Location)
                .WithMany(l => l.Companies)
                .HasForeignKey(e => e.LocationId)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Feedback>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Feedback>()
                .Property(b => b.Message)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .Property(b => b.Rating)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasOne<User>(f => f.Giving)
                .WithMany(u => u.GivingFeedbacks)
                .HasForeignKey(f => f.GivingId)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasOne<User>(f => f.Receiver)
                .WithMany(u => u.ReceivedFeedbacks)
                .HasForeignKey(f => f.ReceiverId)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasOne<Work>(f => f.Work)
                .WithMany(w => w.Feedbacks)
                .HasForeignKey(f => f.WorkId)
                .IsRequired();

            modelBuilder.Entity<Key>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Key>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Key>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Key>()
               .HasMany<WorkKey>(k => k.WorkKeys)
               .WithOne(wk => wk.Key)
               .HasForeignKey(wk => wk.KeyId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Location>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Location>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Location>()
                .Property(b => b.Country)
                .IsRequired();

            modelBuilder.Entity<Location>()
               .HasMany<User>(l => l.Users)
               .WithOne(u => u.Location)
               .HasForeignKey(u => u.LocationId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Location>()
               .HasMany<Employment>(l => l.Companies)
               .WithOne(e => e.Location)
               .HasForeignKey(e => e.LocationId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Portfolio>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Portfolio>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Portfolio>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Portfolio>()
                .Property(b => b.Description)
                .IsRequired();

            modelBuilder.Entity<Portfolio>()
                .HasOne<User>(p => p.User)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
               .Property(b => b.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Proposal>()
                .Property(b => b.Date)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .Property(b => b.DaysCount)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .Property(b => b.Rate)
                .IsRequired();
            
            modelBuilder.Entity<Proposal>()
                .HasOne<User>(uw => uw.User)
                .WithMany(u => u.Proposals)
                .HasForeignKey(uw => uw.UserId)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .HasOne<Work>(uw => uw.Work)
                .WithMany(w => w.Proposals)
                .HasForeignKey(uw => uw.WorkId)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Role>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Role>()
               .HasMany<User>(r => r.Users)
               .WithOne(u => u.Role)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skill>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Skill>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Skill>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Skill>()
               .HasMany<UserSkill>(s => s.UserSkills)
               .WithOne(us => us.Skill)
               .HasForeignKey(u => u.SkillId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<User>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(b => b.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Firstname)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Lastname)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Description)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.DescriptionHeader)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.HourlyRate)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.TimePlusUTC)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Availability)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne<Location>(u => u.Location)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LocationId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne<Role>(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();

            modelBuilder.Entity<User>()
              .HasMany<Work>(u => u.CreatedWorks)
              .WithOne(w => w.Creator)
              .HasForeignKey(w => w.CreatorId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
              .HasMany<UserWork>(uw => uw.UserWorks)
              .WithOne(uw => uw.User)
              .HasForeignKey(uw => uw.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
              .HasMany<Feedback>(u => u.ReceivedFeedbacks)
              .WithOne(f => f.Receiver)
              .HasForeignKey(f => f.ReceiverId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
              .HasMany<Feedback>(u => u.GivingFeedbacks)
              .WithOne(f => f.Giving)
              .HasForeignKey(f => f.GivingId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
              .HasMany<Portfolio>(u => u.Portfolios)
              .WithOne(p => p.User)
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
              .HasMany<Proposal>(u => u.Proposals)
              .WithOne(p => p.User)
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
             .HasMany<UserSkill>(u => u.UserSkills)
             .WithOne(us => us.User)
             .HasForeignKey(us => us.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
             .HasMany<UserCertificate>(u => u.UserCertificates)
             .WithOne(uc => uc.User)
             .HasForeignKey(uc => uc.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
             .HasMany<Employment>(u => u.Employment)
             .WithOne(e => e.User)
             .HasForeignKey(e => e.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
             .HasMany<Education>(u => u.Educations)
             .WithOne(e => e.User)
             .HasForeignKey(e => e.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserCertificate>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<UserCertificate>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserCertificate>()
                .Property(b => b.URL)
                .IsRequired();

            modelBuilder.Entity<UserCertificate>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.UserCertificates)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            modelBuilder.Entity<UserCertificate>()
                .HasOne<Certificate>(uc => uc.Certificate)
                .WithMany(c => c.UserCertificates)
                .HasForeignKey(uc => uc.CertificateId)
                .IsRequired();

            modelBuilder.Entity<UserSkill>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<UserSkill>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserSkill>()
                .HasOne<User>(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId)
                .IsRequired();

            modelBuilder.Entity<UserSkill>()
                .HasOne<Skill>(us => us.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(us => us.SkillId)
                .IsRequired();

            modelBuilder.Entity<UserWork>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<UserWork>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserWork>()
                .Property(b => b.TotalEarned)
                .IsRequired();

            modelBuilder.Entity<UserWork>()
                .Property(b => b.UserRate)
                .IsRequired();

            modelBuilder.Entity<UserWork>()
                .HasOne<User>(uw => uw.User)
                .WithMany(u => u.UserWorks)
                .HasForeignKey(uw => uw.UserId)
                .IsRequired();

            modelBuilder.Entity<UserWork>()
                .HasOne<Work>(uw => uw.Work)
                .WithMany(w => w.UserWorks)
                .HasForeignKey(uw => uw.WorkId)
                .IsRequired();

            modelBuilder.Entity<Work>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Work>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Work>()
                .Property(b => b.Description)
                .IsRequired();

            modelBuilder.Entity<Work>()
                .HasOne<User>(w => w.Creator)
                .WithMany(u => u.CreatedWorks)
                .HasForeignKey(w => w.CreatorId)
                .IsRequired();

            modelBuilder.Entity<Work>()
              .HasMany<UserWork>(w => w.UserWorks)
              .WithOne(uw => uw.Work)
              .HasForeignKey(uw => uw.WorkId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Work>()
             .HasMany<WorkKey>(w => w.WorkKeys)
             .WithOne(wk => wk.Work)
             .HasForeignKey(wk => wk.WorkId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Work>()
             .HasMany<Feedback>(w => w.Feedbacks)
             .WithOne(f => f.Work)
             .HasForeignKey(f => f.WorkId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Work>()
              .HasMany<Proposal>(u => u.Proposals)
              .WithOne(p => p.Work)
              .HasForeignKey(p => p.WorkId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkKey>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<WorkKey>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkKey>()
                .HasOne<Key>(wk => wk.Key)
                .WithMany(k => k.WorkKeys)
                .HasForeignKey(wk => wk.KeyId)
                .IsRequired();

            modelBuilder.Entity<WorkKey>()
                .HasOne<Work>(wk => wk.Work)
                .WithMany(w => w.WorkKeys)
                .HasForeignKey(wk => wk.WorkId)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationDb;Trusted_Connection=True;ConnectRetryCount=0");
        }

    }

    //public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationDb;Trusted_Connection=True;ConnectRetryCount=0");
    //        return new ApplicationDbContext(builder.Options);
    //    }
    //}
}
