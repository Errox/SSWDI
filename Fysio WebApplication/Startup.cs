using Library.core.Model.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Repositories;
using Library.Data;
using Fysio_WebApplication.Seed;
using Library.Data.Repositories;
using Library.Data.Dal;
using Fysio_Identity;
using Library.core.Model;

namespace Fysio_WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ApplicationConnection")));
            
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();


            // Setup Identity
            //services.AddIdentityCore<ApplicationUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.SignIn.RequireConfirmedEmail = false;
            //    options.SignIn.RequireConfirmedPhoneNumber = false;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 0;
            //})
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<AppIdentityDbContext>()
            //    .AddDefaultTokenProviders();//ApplicationRole





            // Setup Controller and Razor pages
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();


            // Dependency injection 
            services.AddTransient<IAppointmentsRepository, EFAppointmentRepository>();
            services.AddTransient<ITreatmentPlanRepository, EFTreatmentPlanRepository>();
            services.AddTransient<IPracticeRoomRepository, EFPracticeRoomRepository>();
            services.AddTransient<IPatientRepository, EFPatientRepository>();
            services.AddTransient<INotesRepository, EFNotesRepository>();
            services.AddTransient<IMedicalFileRepository, EFMedicalFileRepository>();
            services.AddTransient<IAppointmentsRepository, EFAppointmentRepository>();
            services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


            //SeedData.EnsurePopulatedApplication(app);

            // ensure identity populated function
            IdentitySeedData.EnsurePopulated(app);


        }
    }
}
