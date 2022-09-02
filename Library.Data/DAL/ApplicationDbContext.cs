using Library.core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Dal
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<MedicalFile> MedicalFiles { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }

        public DbSet<PracticeRoom> PracticeRooms { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Availabilty> Availabilties { get; set; }

        // TODO: I added these sets from the removed Identities, since this is domain code -W
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
