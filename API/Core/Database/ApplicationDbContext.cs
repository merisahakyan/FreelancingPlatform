using Core.Database;
using Core.FluentAPI;
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
        string connection = "";
        public ApplicationDbContext(string connection)
        {
            this.connection = connection;
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
            modelBuilder.ApplyConfiguration(new CertificateConfigurations());
            modelBuilder.ApplyConfiguration(new EducationConfigurations());
            modelBuilder.ApplyConfiguration(new EmploymentConfigurations());
            modelBuilder.ApplyConfiguration(new FeedbackConfigurations());
            modelBuilder.ApplyConfiguration(new KeyConfigurations());
            modelBuilder.ApplyConfiguration(new LocationConfigurations());
            modelBuilder.ApplyConfiguration(new PortfolioConfigurations());
            modelBuilder.ApplyConfiguration(new ProposalConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
            modelBuilder.ApplyConfiguration(new SkillConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new UserCertificateConfigurations());
            modelBuilder.ApplyConfiguration(new UserSkillConfigurations());
            modelBuilder.ApplyConfiguration(new UserWorkConfigurations());
            modelBuilder.ApplyConfiguration(new WorkConfigurations());
            modelBuilder.ApplyConfiguration(new WorkKeyConfigurations());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationDb;Trusted_Connection=True;ConnectRetryCount=0");
                optionsBuilder.UseSqlServer(connection);
        }

    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationDb;Trusted_Connection=True;ConnectRetryCount=0");
            return new ApplicationDbContext("Server=(localdb)\\mssqllocaldb;Database=ApplicationDb;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
}
