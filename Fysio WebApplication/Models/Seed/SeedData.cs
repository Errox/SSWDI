using Fysio_WebApplication.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Models.SeedData
{
    public class SeedData
    {

        // We seed the database here with function ensure populated.
        // This way we know that if the database is empty on startup. We insert data into the application
        public static void EnsurePopulatedApplication(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //string userId = User;
            string Employee = "b74ddd14-6340-4840-95c2-db12554843e5";
            string Student = "e74ddd12-6340-4840-95c2-db12254843e5";



            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }


            if (!context.MedicalFiles.Any())
            {
                PracticeRoom Room1 = new PracticeRoom
                {
                    Name = "Room: 202"
                };
                context.Add(Room1);

                PracticeRoom Room2 = new PracticeRoom
                {
                    Name = "Room: 204"
                };
                context.Add(Room2);

                PracticeRoom Room3 = new PracticeRoom
                {
                    Name = "Room: 302"
                };
                context.Add(Room3);

                PracticeRoom Room4 = new PracticeRoom
                {
                    Name = "Room: 304"
                };
                context.Add(Room4);

                // Note 1 that patient 1 can't see, made by employee
                Note note1 = new Note
                {
                    Description = "Patient heeft overgegeven op stoel",
                    IdEmployee = Employee,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-2)
                };
                context.Add(note1);

                // Note 2 that patient 1 can see, made by student
                Note note2 = new Note
                {
                    Description = "Patient heeft verteld dat het beter gaat",
                    IdEmployee = Student,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-2)
                };
                context.Add(note2);

                // Note 3 that patient 2 can't see, made by employee
                Note note3 = new Note
                {
                    Description = "Patient heeft blauwe tenen gekregen",
                    IdEmployee = Employee,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-2)
                };
                context.Add(note3);

                // Note 4 that patient 2 can see, made by student
                Note note4 = new Note
                {
                    Description = "Patient had eigen tenen ingekleurd",
                    IdEmployee = Student,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-2)
                };
                context.Add(note4);

                TreatmentPlan treatmentPlan1 = new TreatmentPlan
                {
                    Type = 1500,
                    Description = "Beoefenen van individuele zitting zou genoeg moeten zijn",
                    PracticeRoom = Room2,
                    Particularities = "Let op de teennagels",
                    TreatmentPerformedBy = Student,
                    TreatmentDate = DateTime.Now.AddDays(2),
                    AmountOfTreatmentsPerWeek = 2
                };
                context.Add(treatmentPlan1);
                TreatmentPlan treatmentPlan2 = new TreatmentPlan
                {
                    Type = 1920,
                    Description = "Telefonische zitting zou genoeg meoten zijn voor de fysiotherapie",
                    PracticeRoom = Room1,
                    Particularities = "Let op de manier van spreken, kan erg aggressief zijn.",
                    TreatmentPerformedBy = Employee,
                    TreatmentDate = DateTime.Now.AddDays(1),
                    AmountOfTreatmentsPerWeek = 2
                };
                context.Add(treatmentPlan2);
                TreatmentPlan treatmentPlan3 = new TreatmentPlan
                {
                    Type = 1920,
                    Description = "Meneer vond het niet nodig, maar er is toch spraken van pijn.",
                    PracticeRoom = Room3,
                    Particularities = "Ballontherapie zou genoeg moeten zijn.",
                    TreatmentPerformedBy = Employee,
                    TreatmentDate = DateTime.Now.AddDays(5),
                    AmountOfTreatmentsPerWeek = 2
                };
                context.Add(treatmentPlan3);

                var treatmentplans1 = new List<TreatmentPlan>();
                treatmentplans1.Add(treatmentPlan1);
                var notes = new List<Note>();
                notes.Add(note1);
                notes.Add(note2);
                MedicalFile medicalFile1 = new MedicalFile
                {
                    Description = "Last van de longen, veel uitslag op nek",
                    DiagnosisCode = 5581,
                    IntakeTherapistId = Student,
                    IntakeSupervision = Employee,
                    DateOfCreation = DateTime.Now.AddDays(-2),
                    DateOfDischarge = DateTime.Now.AddDays(5),
                    Notes = notes,
                    TreatmentPlans = treatmentplans1
                };
                context.Add(medicalFile1);


                var treatmentplans2 = new List<TreatmentPlan>();
                treatmentplans2.Add(treatmentPlan2);
                treatmentplans2.Add(treatmentPlan3);
                var notes2 = new List<Note>();
                notes2.Add(note3);
                notes2.Add(note4);
                MedicalFile medicalFile2 = new MedicalFile
                {
                    Description = "Veel last van de duim",
                    DiagnosisCode = 5585,
                    IntakeTherapistId = Employee,
                    IntakeSupervision = Employee,
                    DateOfCreation = DateTime.Now.AddDays(-4),
                    DateOfDischarge = DateTime.Now.AddDays(1),
                    Notes = notes2,
                    TreatmentPlans = treatmentplans2
                };
                context.Add(medicalFile2);

                // Add Hans that isn't a student
                Patient Hans = new Patient
                {
                    FirstName = "Hans",
                    SurName = "Peterson",
                    PhoneNumber = "31637173150",
                    Email = "HansPeterson@geenmail.nl",
                    IdNumber = 420,
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    Gender = EnumGender.Gender.Male,
                    IsStudent = false,
                    MedicalFile = medicalFile1

                };
                context.Add(Hans);

                // Add Laura that is a student
                Patient Laura = new Patient
                {
                    FirstName = "Laura",
                    SurName = "Sok",
                    PhoneNumber = "31637173151",
                    Email = "LauraSok@geenmail.nl",
                    IdNumber = 421,
                    DateOfBirth = DateTime.Now.AddYears(-23),
                    Gender = EnumGender.Gender.Female,
                    IsStudent = true,
                    MedicalFile = medicalFile2
                };
                context.Add(Laura);


                Appointment appointment1 = new Appointment
                {
                    PatientId = Laura.PatientId,
                    EmployeeId = Student
                };
                context.Add(appointment1);

                Appointment appointment2 = new Appointment
                {
                    PatientId = Hans.PatientId,
                    EmployeeId = Student
                };
                context.Add(appointment2);
            }
            context.SaveChanges();
        }
    }
}
