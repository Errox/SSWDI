using Library.core.Model;
using Library.Data.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fysio_WebApplication.Seed
{
    public class SeedData
    {
        public static async void EnsurePopulatedApplicationAsync(IApplicationBuilder app)
        {
            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationDbContext appContext = app.ApplicationServices
                .CreateScope().ServiceProvider.
                GetRequiredService<ApplicationDbContext>();



            // Fetch employee's
            ApplicationUser employeeUser = userManager.FindByNameAsync("rgroen").Result;
            Employee employee = appContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeUser.Id);

            ApplicationUser studentUser = userManager.FindByNameAsync("iiro").Result;
            Employee student = appContext.Employees.FirstOrDefault(e => e.EmployeeId == studentUser.Id);

            // Fetch Patients
            ApplicationUser patientUser = userManager.FindByNameAsync("ola").Result;
            Patient patient1 = appContext.Patients.FirstOrDefault(e => e.PatientId == patientUser.Id);

            ApplicationUser patient2User = userManager.FindByNameAsync("sri").Result;
            Patient patient2 = appContext.Patients.FirstOrDefault(e => e.PatientId == patient2User.Id);



            if (!appContext.MedicalFiles.Any() && employee != null)
            {
                PracticeRoom Room1 = new PracticeRoom
                {
                    Name = "Room: 202"
                };
                appContext.Add(Room1);

                PracticeRoom Room2 = new PracticeRoom
                {
                    Name = "Room: 204"
                };
                appContext.Add(Room2);

                PracticeRoom Room3 = new PracticeRoom
                {
                    Name = "Room: 302"
                };
                appContext.Add(Room3);

                PracticeRoom Room4 = new PracticeRoom
                {
                    Name = "Room: 304"
                };
                appContext.Add(Room4);

                // Note 1 that patient 1 can't see, made by employee
                Note note1 = new Note
                {
                    Description = "Patient heeft overgegeven op stoel",
                    Employee = employee,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-3)
                };
                appContext.Add(note1);

                // Note 2 that patient 1 can see, made by student
                Note note2 = new Note
                {
                    Description = "Patient heeft verteld dat het beter gaat",
                    Employee = student,
                    OpenForPatient = true,
                    CreatedUtc = DateTime.Now.AddDays(-2)
                };
                appContext.Add(note2);

                // Note 3 that patient 2 can't see, made by employee
                Note note3 = new Note
                {
                    Description = "Patient heeft blauwe tenen gekregen",
                    Employee = employee,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-4)
                };
                appContext.Add(note3);

                // Note 4 that patient 2 can see, made by student
                Note note4 = new Note
                {
                    Description = "Patient had eigen tenen ingekleurd",
                    Employee = student,
                    OpenForPatient = true,
                    CreatedUtc = DateTime.Now.AddDays(-3)
                };
                appContext.Add(note4);

                // Note 5 that patient 1 can see, made by employee
                Note note5 = new Note
                {
                    Description = "Patient heeft een nieuwe bril gekregen",
                    Employee = employee,
                    OpenForPatient = false,
                    CreatedUtc = DateTime.Now.AddDays(-20)
                };
                appContext.Add(note5);

                TreatmentPlan treatmentPlan1 = new TreatmentPlan
                {
                    Type = 1500,
                    Description = "Beoefenen van individuele zitting zou genoeg moeten zijn",
                    PracticeRoom = Room2,
                    Particularities = "Let op de teennagels",
                    TreatmentPerformedBy = student,
                    TreatmentDate = DateTime.Now.AddDays(2),
                    AmountOfTreatmentsPerWeek = 2
                };
                appContext.Add(treatmentPlan1);
                TreatmentPlan treatmentPlan2 = new TreatmentPlan
                {
                    Type = 1920,
                    Description = "Telefonische zitting zou genoeg meoten zijn voor de fysiotherapie",
                    PracticeRoom = Room1,
                    Particularities = "Let op de manier van spreken, kan erg aggressief zijn.",
                    TreatmentPerformedBy = employee,
                    TreatmentDate = DateTime.Now.AddDays(1),
                    AmountOfTreatmentsPerWeek = 2
                };

                appContext.Add(treatmentPlan2);
                TreatmentPlan treatmentPlan3 = new TreatmentPlan
                {
                    Type = 1920,
                    Description = "Meneer vond het niet nodig, maar er is toch spraken van pijn.",
                    PracticeRoom = Room3,
                    Particularities = "Ballontherapie zou genoeg moeten zijn.",
                    TreatmentPerformedBy = employee,
                    TreatmentDate = DateTime.Now.AddDays(5),
                    AmountOfTreatmentsPerWeek = 2
                };
                appContext.Add(treatmentPlan3);

                var treatmentplans1 = new List<TreatmentPlan>();
                treatmentplans1.Add(treatmentPlan1);
                var notes = new List<Note>();
                notes.Add(note1);
                notes.Add(note2);
                MedicalFile medicalFile1 = new MedicalFile
                {
                    Description = "Last van de longen, veel uitslag op nek",
                    DiagnosisCode = 5581,
                    IntakeTherapistId = student,
                    IntakeSupervision = employee,
                    DateOfCreation = DateTime.Now.AddDays(-2),
                    DateOfDischarge = DateTime.Now.AddDays(5),
                    Notes = notes,
                    TreatmentPlans = treatmentplans1
                };
                appContext.Add(medicalFile1);


                var treatmentplans2 = new List<TreatmentPlan>();
                treatmentplans2.Add(treatmentPlan2);
                treatmentplans2.Add(treatmentPlan3);
                var notes2 = new List<Note>();
                notes2.Add(note3);
                notes2.Add(note4);
                notes2.Add(note5);
                MedicalFile medicalFile2 = new MedicalFile
                {
                    Description = "Veel last van de duim",
                    DiagnosisCode = 5585,
                    IntakeTherapistId = employee,
                    IntakeSupervision = employee,
                    DateOfCreation = DateTime.Now.AddDays(-4),
                    DateOfDischarge = DateTime.Now.AddDays(1),
                    Notes = notes2,
                    TreatmentPlans = treatmentplans2
                };
                appContext.Add(medicalFile2);

                patient1.MedicalFile = medicalFile1;
                appContext.Patients.Update(patient1);

                patient2.MedicalFile = medicalFile2;
                appContext.Patients.Update(patient2);

                Appointment appointment1 = new Appointment
                {
                    Patient = patient1,
                    Employee = employee,
                    Date = DateTime.Now.AddDays(1)
                };
                appContext.Add(appointment1);

                Appointment appointment2 = new Appointment
                {
                    Patient = patient2,
                    Employee = student,
                    Date = DateTime.Now.AddDays(1)
                };
                appContext.Add(appointment2);

                Availabilty availabiltyEmployee = new Availabilty
                {
                    Employee = employee,
                    StartAvailability = DateTime.Now.AddDays(-7),
                    StopAvailability = DateTime.Now.AddDays(2)
                };
                appContext.Add(availabiltyEmployee);

                Availabilty availabiltyStudent = new Availabilty
                {
                    Employee = employee,
                    StartAvailability = DateTime.Now.AddDays(-7),
                    StopAvailability = DateTime.Now.AddDays(2)
                };
                appContext.Add(availabiltyStudent);

                appContext.SaveChanges();
            }
        }
    }
}
