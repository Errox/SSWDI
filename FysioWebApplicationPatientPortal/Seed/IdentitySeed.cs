using Library.core.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioWebApplicationPatientPortal.Seed
{
    public class IdentitySeedDataPatient
    {

        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            Patient Hans = new Patient
            {
                UserName = "HansPeterson@geenmail.nl",
                NormalizedEmail = "HANSPETERSON@GEENMAIL.NL",
                NormalizedUserName = "HANSPETERSON@GEENMAIL.NL",
                LockoutEnabled = false,
                FirstName = "Hans",
                SurName = "Peterson",
                PhoneNumber = "31637173150",
                Email = "HansPeterson@geenmail.nl",
                IdNumber = 420,
                DateOfBirth = DateTime.Now.AddYears(-20),
                Gender = EnumGender.Gender.Male,
                IsStudent = false
            };

            // Add Laura that is a student
            Patient Laura = new Patient
            {
                UserName = "LauraSok@geenmail.nl",
                NormalizedEmail = "LAURASOK@GEENMAIL.NL",
                NormalizedUserName = "LAURASOK@GEENMAIL.NL",
                LockoutEnabled = false,
                FirstName = "Laura",
                SurName = "Sok",
                PhoneNumber = "31637173151",
                Email = "LauraSok@geenmail.nl",
                IdNumber = 421,
                DateOfBirth = DateTime.Now.AddYears(-23),
                Gender = EnumGender.Gender.Female,
                IsStudent = true,
            };

            UserManager<Patient> userManagerPatient = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<Patient>>();
            await userManagerPatient.CreateAsync(Laura, "Laura*123");
            await userManagerPatient.CreateAsync(Hans, "Hans*123");
        }
    }
}
