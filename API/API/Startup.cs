using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Core.Database;
using Core.OperationInterfaces;
using BLL.Operations;
using Core.RepositoryInterfaces;
using DAL.Repositories;
using Core;
using DAL;

namespace API
{
    public class Startup
    {
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ApplicationDb;Trusted_Connection=True;ConnectRetryCount=0";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton(typeof(IUserOperations), typeof(UserOperations));
            services.AddSingleton(typeof(IProposalOperations), typeof(ProposalOperations));
            services.AddSingleton(typeof(IWorkOperations), typeof(WorkOperations));

            services.AddSingleton(typeof(ICertificateRepository), typeof(CertificateRepository));
            services.AddSingleton(typeof(IEducationRepository), typeof(EducationRepository));
            services.AddSingleton(typeof(IEmploymentRepository), typeof(EploymentRepository));
            services.AddSingleton(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddSingleton(typeof(IKeyRepository), typeof(KeyRepository));
            services.AddSingleton(typeof(ILocationRepository), typeof(LocationRepository));
            services.AddSingleton(typeof(IPortfolioRepository), typeof(PortfolioRepository));
            services.AddSingleton(typeof(IProposalRepository), typeof(ProposalRepository));
            services.AddSingleton(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddSingleton(typeof(ISkillRepository), typeof(SkillRepository));
            services.AddSingleton(typeof(IUserCertificateRepositiry), typeof(UserCertificateRepository));
            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton(typeof(IUserSkillRepository), typeof(UserSkillRepository));
            services.AddSingleton(typeof(IUserWorkRepository), typeof(UserWorkRepository));
            services.AddSingleton(typeof(IWorkKeyRepository), typeof(WorkKeyRepository));
            services.AddSingleton(typeof(IWorkRepository), typeof(WorkRepository));

            services.AddSingleton(typeof(IRepositoryManager), typeof(RepositoryManager));

            var connection = ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }

    }
}
