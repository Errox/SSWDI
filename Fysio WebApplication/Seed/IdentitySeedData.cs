using Fysio_Identity;
using Library.core.Model;
using Library.Data.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;

namespace Fysio_WebApplication.Seed
{
    public class IdentitySeedData
    {
        private const string adminPassword = "Secret1234!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

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


            const string claimUserType = "UserType";
            Claim EmployeeUserClaim = new Claim(claimUserType, "Employee");
            Claim studentUserClaim = new Claim(claimUserType, "Student");
            Claim patientUserClaim = new Claim(claimUserType, "Patient");


            // Create Employee user if not exists
            if (userManager.FindByNameAsync("Employee").Result == null)
            {

                // When no user is found. Let's create a "employee" account. 
                ApplicationUser userEmployee = new ApplicationUser()
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

                await userManager.CreateAsync(userEmployee, adminPassword);

                ApplicationUser userID = userManager.FindByNameAsync(userEmployee.UserName).Result;

                Employee employee = new Employee();
                employee.WorkerNumber = 20000;
                employee.BIGNumber = 1582648952;
                employee.IsStudent = false;
                employee.ApplicationUser = userID;
                // Save the employee in context
                appContext.Employees.Add(employee);
                appContext.SaveChanges();

                await userManager.AddClaimAsync(userEmployee, EmployeeUserClaim);
            }
            // Create patient user if not exists 
            if (userManager.FindByNameAsync("Patient").Result == null)
            {
                ApplicationUser userPatient = new ApplicationUser()
                {
                    // Add the "employee" role to the new "employee" user we just created
                    UserName = "Patient",
                    FirstName = "Patientia",
                    SurName = "Beterhorend",
                    Email = "patient@hotmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0612345678",
                    PhoneNumberConfirmed = true,
                };

                // Set role to patient
                await userManager.CreateAsync(userPatient, adminPassword);

                ApplicationUser result = userManager.FindByNameAsync(userPatient.UserName).Result;
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


                await userManager.AddClaimAsync(userPatient, patientUserClaim);
            }
        }
    }
}
