using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        string connection = "";
        
        public ApplicationDbContext(string connection)
        {
            this.connection = connection;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connection);
        }
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MvcApplicationDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ApplicationDbContext("Server=(localdb)\\mssqllocaldb;Database=MvcApplicationDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
