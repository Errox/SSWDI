using Fysio_Identity;
using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Seed
{
    public class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "Secret1234!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService <AppIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationDbContext appContext = app.ApplicationServices
                .CreateScope().ServiceProvider.
                GetRequiredService<ApplicationDbContext>();



            //if (!roleManager.RoleExistsAsync("Employee").Result)
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Employee";
            //    await roleManager.CreateAsync(role);
            //}

            //if (!roleManager.RoleExistsAsync("Patient").Result)
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Patient";
            //    await roleManager.CreateAsync(role);
            //}

            // Create Employee user if not exists
            if (userManager.FindByNameAsync("Employee").Result == null)
            {

                // When no user is found. Let's create a "employee" account. 
                ApplicationUser user = new ApplicationUser()
                {
                    // Add the "employee" role to the new "employee" user we just created
                    UserName = "Employee",
                    FirstName = "Ryan",
                    SurName = "Groenewold",
                    Email = "employee@hotmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0612345678",
                    PhoneNumberConfirmed = true,
                };
                // add the employee roll to the new user

                // Set role to employee
                IdentityResult result = await userManager.CreateAsync(user, adminPassword);
                ApplicationUser userID = userManager.FindByNameAsync("Employee").Result;
                //await userManager.AddToRoleAsync(user, "Employee");

                Employee employee = new Employee();
                employee.WorkerNumber = 20000;
                employee.BIGNumber = 1582648952;
                employee.IsStudent = false;
                employee.ApplicationUser = userID;
                // Save the employee in context
                var res = appContext.Employees.Add(employee);
                appContext.SaveChanges();


                // Exact way of getting a logged in user. Just fetching a employee from db context will give also the applicationuser credentials
                //ApplicationUser use = userManager.FindByNameAsync("Employee").Result;
                //Console.WriteLine(use);
                //Employee emm = appContext.Employees.FirstOrDefault(x => x.EmployeeId == use.Id);
            }
            // Create patient user if not exists 
            if (userManager.FindByNameAsync("Patient").Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    // Add the "employee" role to the new "employee" user we just created
                    UserName = "Patient",
                    FirstName = "Patiencia",
                    SurName = "Beterhorend",
                    Email = "patient@hotmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0612345678",
                    PhoneNumberConfirmed = true,
                };

                // Set role to patient
                await userManager.CreateAsync(user, adminPassword);
                var result = userManager.FindByNameAsync("Patient").Result;
                //await userManager.AddToRoleAsync(user, "Patient"); // TODO: Get roles working. Follow ebook.

                // Make new patient with the application user we just created
                Patient patient = new Patient();
                patient.ApplicationUser = result;
                patient.IdNumber = 2000001;
                patient.Gender = EnumGender.Gender.Male;
                patient.DateOfBirth = DateTime.Now.AddYears(-18);
                patient.IsStudent = false;
                patient.ApplicationUser = result;
                // Save patient in context
                appContext.Patients.Add(patient);
                appContext.SaveChanges();
            }
        }
    }
}
