using Library.core.Model;
using Library.Data.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Seed
{
    public static class IdentitySeedData
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            // TODO: Temp disabled this code to fix later -W
            /*
            //Setup Therapist
            Employee employee = new Employee()
            {
                UserName = "ryangroenewold@hotmail.com",
                NormalizedEmail = "RYANGROENEWOLD@HOTMAIL.COM",
                Email = "ryangroenewold@hotmail.com",
                NormalizedUserName = "RYANGROENEWOLD@HOTMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "+31637173150",
                FirstName = "Ryan",
                SurName = "Groenewold",
                WorkerNumber = 8527442,
                BIGNumber = 1000052,
                IsStudent = false
            };

            // Setup Student
            Employee student = new Employee()
            {
                UserName = "Student@student.nl",
                NormalizedEmail = "STUDENT@STUDENT.NL",
                Email = "Student@student.nl",
                NormalizedUserName = "STUDENT@STUDENT.NL",
                LockoutEnabled = false,
                PhoneNumber = "+31637173151",
                FirstName = "Ida",
                SurName = "Jones",
                WorkerNumber = 8527441,
                StudentNumber = 1000052,
                IsStudent = true
            };

            UserManager<Employee> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<Employee>>();
            await userManager.CreateAsync(employee, "Ryan*123");
            await userManager.CreateAsync(student, "Student*123");
            */

        }
    }
}
