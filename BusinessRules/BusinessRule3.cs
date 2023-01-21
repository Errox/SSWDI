using Core.DomainModel;
using Core.Enums;
using DomainServices.Repositories;
using DomainServices.Services;
using Moq;
using Services;

namespace BusinessRules
{
    public class BusinessRule3
    {
        [Fact]
        public void PatientCantGetATreatmentIfPatientDoesntExist()
        {
            // TreatmentPlan can only be made when a patient is registered.
            Mock<IMedicalFileRepository> medicalFileRepository = new Mock<IMedicalFileRepository>();
            Mock<ITreatmentPlanRepository> treatmentPlanRepository = new Mock<ITreatmentPlanRepository>();
            Mock<IAppointmentsRepository> AppointmentsRepository = new Mock<IAppointmentsRepository>();

            IMedicalFileService medicalFileService = new MedicalFileService(medicalFileRepository.Object, treatmentPlanRepository.Object, AppointmentsRepository.Object);
            
            MedicalFile medicalFile = new MedicalFile
            {
                Id = 1,
                Description = "Test Description",
                IntakeTherapistId = new Employee
                {
                    FirstName = "John",
                    SurName = "Doe",
                    Email = "JohnDoe@mail.nl",
                    PhoneNumber = "0612345678",
                    WorkerNumber = 20000,
                    BIGNumber = 200000,
                    IsStudent = false,
                },
                IntakeSupervision = new Employee
                {
                    FirstName = "John",
                    SurName = "Doe",
                    Email = "JohnDoe@mail.nl",
                    PhoneNumber = "0612345678",
                    WorkerNumber = 20000,
                    BIGNumber = 200000,
                    IsStudent = false,
                },
                DateOfCreation = DateTime.Now.AddDays(5),
                DateOfDischarge = DateTime.Now.AddDays(6)
            };

            TreatmentPlan treatmentPlan = new TreatmentPlan
            {
                Type = 1500,
                Description = "Beschrijving",
                Particularities = "Bijzonderheden",
                TreatmentPerformedBy = new Employee
                {
                    FirstName = "John",
                    SurName = "Doe",
                    Email = "JohnDoe@mail.nl",
                    PhoneNumber = "0612345678",
                    WorkerNumber = 20000,
                    BIGNumber = 200000,
                    IsStudent = false,
                },
                TreatmentDate = DateTime.Now.AddDays(5),
                AmountOfTreatmentsPerWeek = 1
            };

            medicalFileRepository.Setup(e => e.GetMedicalFile(medicalFile.Id))
                .Returns(medicalFile);

            // act
            Action act = () => medicalFileService.AddTreatmentPlanToMedicalFile(medicalFile.Id, treatmentPlan);

            //assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.Equal("A treatment can only be set when the patient is registered in the system", exception.Message);


            // assert

        }
    }
}