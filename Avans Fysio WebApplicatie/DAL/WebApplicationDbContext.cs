using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.Data
{
    public class WebApplicationDbContext : DbContext
    {
        public WebApplicationDbContext(DbContextOptions<WebApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Therapist> Therapists{ get; set; }

        public DbSet<MedicalFile> MedicalFiles { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Patient> Patients { get; set; }
    }
}
