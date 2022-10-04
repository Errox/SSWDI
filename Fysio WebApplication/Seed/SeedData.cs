using Microsoft.AspNetCore.Builder;

namespace Library.core.Model.SeedData
{
    public class SeedData
    {

        // We seed the database here with function ensure populated.
        public static void EnsurePopulatedApplication(IApplicationBuilder app)
        {
            //ApplicationDbContext context = app.ApplicationServices
            //    .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //// PatientPortalDbContext contextPatient = app.ApplicationServices
            ////    .CreateScope().ServiceProvider.GetRequiredService<PatientPortalDbContext>();

            //AppIdentityDbContext contextEmployee = app.ApplicationServices
            //    .CreateScope().ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            //// Fetch employee's
            //// TODO: Changed Identity Context to Domain Context -W
            //Employee employee = contextEmployee.Employees.FirstOrDefault(i => i.Email == "ryangroenewold@hotmail.com");
            //Employee student = contextEmployee.Employees.FirstOrDefault(i => i.Email == "Student@student.nl");

            //// Fetch Patients
            //Patient patient1 = contextEmployee.Patients.FirstOrDefault(i => i.Email == "HansPeterson@geenmail.nl");
            //Patient patient2 = contextEmployee.Patients.FirstOrDefault(i => i.Email == "LauraSok@geenmail.nl");

            //if (context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.Migrate();
            //}


            //if (!context.MedicalFiles.Any())
            //{
            //    PracticeRoom Room1 = new PracticeRoom
            //    {
            //        Name = "Room: 202"
            //    };
            //    context.Add(Room1);

            //    PracticeRoom Room2 = new PracticeRoom
            //    {
            //        Name = "Room: 204"
            //    };
            //    context.Add(Room2);

            //    PracticeRoom Room3 = new PracticeRoom
            //    {
            //        Name = "Room: 302"
            //    };
            //    context.Add(Room3);

            //    PracticeRoom Room4 = new PracticeRoom
            //    {
            //        Name = "Room: 304"
            //    };
            //    context.Add(Room4);

            //    // Note 1 that patient 1 can't see, made by employee
            //    Note note1 = new Note
            //    {
            //        Description = "Patient heeft overgegeven op stoel",
            //        Employee = employee,
            //        OpenForPatient = false,
            //        CreatedUtc = DateTime.Now.AddDays(-2)
            //    };
            //    context.Add(note1);

            //    // Note 2 that patient 1 can see, made by student
            //    Note note2 = new Note
            //    {
            //        Description = "Patient heeft verteld dat het beter gaat",
            //        Employee = student,
            //        OpenForPatient = false,
            //        CreatedUtc = DateTime.Now.AddDays(-2)
            //    };
            //    context.Add(note2);

            //    // Note 3 that patient 2 can't see, made by employee
            //    Note note3 = new Note
            //    {
            //        Description = "Patient heeft blauwe tenen gekregen",
            //        Employee = employee,
            //        OpenForPatient = false,
            //        CreatedUtc = DateTime.Now.AddDays(-2)
            //    };
            //    context.Add(note3);

            //    // Note 4 that patient 2 can see, made by student
            //    Note note4 = new Note
            //    {
            //        Description = "Patient had eigen tenen ingekleurd",
            //        Employee = student,
            //        OpenForPatient = false,
            //        CreatedUtc = DateTime.Now.AddDays(-2)
            //    };
            //    context.Add(note4);

            //    TreatmentPlan treatmentPlan1 = new TreatmentPlan
            //    {
            //        Type = 1500,
            //        Description = "Beoefenen van individuele zitting zou genoeg moeten zijn",
            //        PracticeRoom = Room2,
            //        Particularities = "Let op de teennagels",
            //        TreatmentPerformedBy = student,
            //        TreatmentDate = DateTime.Now.AddDays(2),
            //        AmountOfTreatmentsPerWeek = 2
            //    };
            //    context.Add(treatmentPlan1);
            //    TreatmentPlan treatmentPlan2 = new TreatmentPlan
            //    {
            //        Type = 1920,
            //        Description = "Telefonische zitting zou genoeg meoten zijn voor de fysiotherapie",
            //        PracticeRoom = Room1,
            //        Particularities = "Let op de manier van spreken, kan erg aggressief zijn.",
            //        TreatmentPerformedBy = employee,
            //        TreatmentDate = DateTime.Now.AddDays(1),
            //        AmountOfTreatmentsPerWeek = 2
            //    };

            //    context.Add(treatmentPlan2);
            //    TreatmentPlan treatmentPlan3 = new TreatmentPlan
            //    {
            //        Type = 1920,
            //        Description = "Meneer vond het niet nodig, maar er is toch spraken van pijn.",
            //        PracticeRoom = Room3,
            //        Particularities = "Ballontherapie zou genoeg moeten zijn.",
            //        TreatmentPerformedBy = employee,
            //        TreatmentDate = DateTime.Now.AddDays(5),
            //        AmountOfTreatmentsPerWeek = 2
            //    };
            //    context.Add(treatmentPlan3);

            //    var treatmentplans1 = new List<TreatmentPlan>();
            //    treatmentplans1.Add(treatmentPlan1);
            //    var notes = new List<Note>();
            //    notes.Add(note1);
            //    notes.Add(note2);
            //    MedicalFile medicalFile1 = new MedicalFile
            //    {
            //        Description = "Last van de longen, veel uitslag op nek",
            //        DiagnosisCode = 5581,
            //        IntakeTherapistId = student,
            //        IntakeSupervision = employee,
            //        DateOfCreation = DateTime.Now.AddDays(-2),
            //        DateOfDischarge = DateTime.Now.AddDays(5),
            //        Notes = notes,
            //        TreatmentPlans = treatmentplans1
            //    };
            //    context.Add(medicalFile1);


            //    var treatmentplans2 = new List<TreatmentPlan>();
            //    treatmentplans2.Add(treatmentPlan2);
            //    treatmentplans2.Add(treatmentPlan3);
            //    var notes2 = new List<Note>();
            //    notes2.Add(note3);
            //    notes2.Add(note4);
            //    MedicalFile medicalFile2 = new MedicalFile
            //    {
            //        Description = "Veel last van de duim",
            //        DiagnosisCode = 5585,
            //        IntakeTherapistId = employee,
            //        IntakeSupervision = employee,
            //        DateOfCreation = DateTime.Now.AddDays(-4),
            //        DateOfDischarge = DateTime.Now.AddDays(1),
            //        Notes = notes2,
            //        TreatmentPlans = treatmentplans2
            //    };
            //    context.Add(medicalFile2);
            //    // TODO: Patient is not created yet.
            //    patient1.MedicalFile = medicalFile1;
            //    context.Patients.Update(patient1);

            //    patient2.MedicalFile = medicalFile2;
            //    context.Patients.Update(patient2);

            //    Appointment appointment1 = new Appointment
            //    {
            //        Patient = patient1,
            //        Employee = employee,
            //        Date = DateTime.Now.AddDays(1)
            //    };
            //    context.Add(appointment1);

            //    Appointment appointment2 = new Appointment
            //    {
            //        Patient = patient2,
            //        Employee = student,
            //        Date = DateTime.Now.AddDays(1)
            //    };
            //    context.Add(appointment2);

            //    Availabilty availabiltyEmployee = new Availabilty
            //    {
            //        Employee = employee,
            //        StartAvailability = DateTime.Now.AddDays(-7),
            //        StopAvailability = DateTime.Now.AddDays(2)
            //    };
            //    context.Add(availabiltyEmployee);

            //    Availabilty availabiltyStudent = new Availabilty
            //    {
            //        Employee = employee,
            //        StartAvailability = DateTime.Now.AddDays(-7),
            //        StopAvailability = DateTime.Now.AddDays(2)
            //    };
            //    context.Add(availabiltyStudent);

            //    context.SaveChanges();
            //}
        }
    }
}
