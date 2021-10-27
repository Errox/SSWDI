using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fysio_WebApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fysio_WebApplication.Data
{
    public class AppIdentityDbContext : IdentityDbContext<Employee>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //Setup Therapist
            Employee employee = new Employee()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "ryangroenewold@hotmail.com",
                Email = "ryangroenewold@hotmail.com",
                LockoutEnabled = false,
                PhoneNumber = "+3163173150",
                FirstName = "Ryan",
                SurName = "Groenewold",
                WorkerNumber = 8527441,
                BIGNumber = 1000052,
                IsStudent = false
            };


            Employee student = new Employee()
            {
                Id = "e74ddd12-6340-4840-95c2-db12254843e5",
                UserName = "Student@student.nl",
                Email = "Student@student.nl",
                LockoutEnabled = false,
                PhoneNumber = "+3163173150",
                FirstName = "Ida",
                SurName = "Jones",
                WorkerNumber = 8527441,
                StudentNumber = 1000052,
                IsStudent = true
            };

            PasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();

            employee.PasswordHash = passwordHasher.HashPassword(employee, "ryan*123");
            student.PasswordHash = passwordHasher.HashPassword(employee, "student*123");


            builder.Entity<Employee>().HasData(employee);
            builder.Entity<Employee>().HasData(student);
        }
    }
}
