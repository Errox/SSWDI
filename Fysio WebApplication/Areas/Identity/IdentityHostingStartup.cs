using System;
using Library.core.Model;
using Library.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Fysio_WebApplication.Areas.Identity.IdentityHostingStartup))]
namespace Fysio_WebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityConnection")));

                services.AddDefaultIdentity<Employee>(options => {
                    //Signin
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    //Password
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;

                    //LockOut
                    options.Lockout.MaxFailedAccessAttempts = 99;

                }).AddEntityFrameworkStores<AppIdentityDbContext>();
            });
        }
    }
}