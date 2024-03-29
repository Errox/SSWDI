﻿using Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.DAL
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

        public DbSet<Availability> Availabilties { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.
        //}
    }
}
