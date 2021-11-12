using Library.core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
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
    }
}
