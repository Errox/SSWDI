using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class PatientPortalDbContext : IdentityDbContext<Patient>
    {
        public PatientPortalDbContext(DbContextOptions<PatientPortalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
