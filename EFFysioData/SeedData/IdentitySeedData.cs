using Core.DomainModel;
using Core.Enums;
using EFFysioData.DAL;
using Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;

namespace EFFysioData.SeedData
{
    public class IdentitySeedData
    {
        private const string adminPassword = "Secret1234!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            // DOesn't work

            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

            //if (context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.Migrate();
            //}

            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationDbContext appContext = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            const string claimUserType = "UserType";
            Claim EmployeeUserClaim = new Claim(claimUserType, "Employee");
            Claim studentUserClaim = new Claim(claimUserType, "Student");
            Claim patientUserClaim = new Claim(claimUserType, "Patient");

            // Create Employee user if not exists
            if (userManager.FindByNameAsync("rgroen").Result == null)
            {
                ApplicationUser userEmployee = new ApplicationUser()
                {
                    UserName = "rgroen",
                    FirstName = "Ryan",
                    SurName = "Groenewold",
                    Email = "ryangroenewold@hotmail.com",
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

            // Create student user if not exists
            if (userManager.FindByNameAsync("iiro").Result == null)
            {
                ApplicationUser userStudent = new ApplicationUser()
                {
                    UserName = "iiro",
                    FirstName = "Iiro",
                    SurName = "Charmian",
                    Email = "IiroCharmian@student.nl",
                    EmailConfirmed = true,
                    PhoneNumber = "0612345678",
                    PhoneNumberConfirmed = true,
                };

                await userManager.CreateAsync(userStudent, adminPassword);

                ApplicationUser userID = userManager.FindByNameAsync(userStudent.UserName).Result;

                Employee student = new Employee();
                student.WorkerNumber = 20005;
                student.BIGNumber = 1582648952;
                student.IsStudent = false;
                student.ApplicationUser = userID;
                // Save the student in context of employee
                appContext.Employees.Add(student);
                appContext.SaveChanges();

                await userManager.AddClaimAsync(userStudent, studentUserClaim);
            }

            // Create patient user if not exists 
            if (userManager.FindByNameAsync("ola").Result == null)
            {
                ApplicationUser userPatient = new ApplicationUser()
                {
                    UserName = "ola",
                    FirstName = "Ola",
                    SurName = "Eliza",
                    Email = "olaEliza@hotmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0612345678",
                    PhoneNumberConfirmed = true,
                };

                await userManager.CreateAsync(userPatient, adminPassword);

                ApplicationUser result = userManager.FindByNameAsync(userPatient.UserName).Result;

                // Make new patient with the application user we just created
                Patient patient = new Patient();
                patient.ApplicationUser = result;
                patient.IdNumber = 2000002;
                patient.Gender = EnumGender.Gender.Female;
                patient.DateOfBirth = DateTime.Now.AddYears(-18);
                patient.IsStudent = false;
                patient.ApplicationUser = result;
                // Save patient in context
                appContext.Patients.Add(patient);
                appContext.SaveChanges();

                await userManager.AddClaimAsync(userPatient, patientUserClaim);
            }

            // Create extra patient. If username is not found, make new user.
            if (userManager.FindByNameAsync("sri").Result == null)
            {
                ApplicationUser userPatient = new ApplicationUser()
                {
                    UserName = "sri",
                    FirstName = "Sri",
                    SurName = "Judd",
                    Email = "sriJudd@hotmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0612345678",
                    PhoneNumberConfirmed = true,
                };

                await userManager.CreateAsync(userPatient, adminPassword);

                ApplicationUser result = userManager.FindByNameAsync(userPatient.UserName).Result;

                // Make new patient with the application user we just created
                Patient patient = new Patient();
                patient.ApplicationUser = result;
                patient.IdNumber = 2000081;
                patient.Gender = EnumGender.Gender.Male;
                patient.DateOfBirth = DateTime.Now.AddYears(-18);
                patient.IsStudent = true;
                patient.ApplicationUser = result;
                // Save patient in context
                appContext.Patients.Add(patient);
                appContext.SaveChanges();

                await userManager.AddClaimAsync(userPatient, patientUserClaim);
            }

            var seedeData = new SeedData();
            seedeData.EnsurePopulatedApplicationAsync(app);

        }
    }
}
