using System;
using Library.core.Model;
using Library.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FysioWebApplicationPatientPortal.Areas.Identity.IdentityHostingStartup))]
namespace FysioWebApplicationPatientPortal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PatientPortalDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PatientPortalDbContextConnection")));

                services.AddDefaultIdentity<Patient>(options => {
                    //Signin
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    //Password
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;

                    //LockOut
                    options.Lockout.MaxFailedAccessAttempts = 99;

                }).AddEntityFrameworkStores<PatientPortalDbContext>();
            });
        }
    }
}