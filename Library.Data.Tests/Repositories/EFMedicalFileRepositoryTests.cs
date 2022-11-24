using Core.DomainModel;
using DomainServices.Repositories;
using Fysio_WebApplication.Controllers;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
namespace Library.Data.Tests.Repositories
{
    public class EFMedicalFileRepositoryTests
    {
        private Mock<IMedicalFileRepository> mock = new Mock<IMedicalFileRepository>();
        private Mock<IEmployeeRepository> mockEmployee = new Mock<IEmployeeRepository>();
        private Mock<IPatientRepository> mockPatient = new Mock<IPatientRepository>();
        private Mock<ITreatmentPlanRepository> mockTreatment = new Mock<ITreatmentPlanRepository>();
        private Mock<INotesRepository> mockNotes = new Mock<INotesRepository>();
        private Mock<IAppointmentsRepository> mockAppointments = new Mock<IAppointmentsRepository>();
        private Mock<IAvailabilityRepository> mockAvailability = new Mock<IAvailabilityRepository>();
        private Mock<IPracticeRoomRepository> mockPracticeRoom = new Mock<IPracticeRoomRepository>();
        private Mock<IGraphQLClient> mockGraphQLClient = new Mock<IGraphQLClient>();
        private Claim[] claims;

        public EFMedicalFileRepositoryTests()
        {
            mock = new Mock<IMedicalFileRepository>();
            mockEmployee = new Mock<IEmployeeRepository>();
            mockPatient = new Mock<IPatientRepository>();
            mockTreatment = new Mock<ITreatmentPlanRepository>();
            mockNotes = new Mock<INotesRepository>();
            mockAppointments = new Mock<IAppointmentsRepository>();
            mockAvailability = new Mock<IAvailabilityRepository>();
            mockPracticeRoom = new Mock<IPracticeRoomRepository>();
            mockGraphQLClient = new Mock<IGraphQLClient>();
        }


        [Fact]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFile = getMedicalFileSample();
            mock.Setup(x => x.MedicalFiles).Returns(medicalFile.AsQueryable());
            var controller = new MedicalFileController(mock.Object, mockEmployee.Object, mockPatient.Object, mockTreatment.Object, mockNotes.Object, mockAppointments.Object, mockGraphQLClient.Object, mockAvailability.Object, mockPracticeRoom.Object);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(claims))
                }
            };

            // Act
            var actionResult = controller.Index();
            var result = actionResult as ViewResult;
            var model = result.Model as IEnumerable<MedicalFile>;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(getMedicalFileSample().Count(), model.Count());
        }

        private List<MedicalFile> getMedicalFileSample()
        {
            List<MedicalFile> output = new List<MedicalFile>
            {
                new MedicalFile
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
                    DateOfDischarge = DateTime.Now.AddDays(6),
                    PatientEmail = "JopDop@mail.nl"
                },
                new MedicalFile
                {
                    Id = 1,
                    Description = "Test Description2",
                    IntakeTherapistId = new Employee
                    {
                        FirstName = "John2",
                        SurName = "Doe2",
                        Email = "JohnDoe2@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20000,
                        BIGNumber = 200000,
                        IsStudent = false,
                    },
                    IntakeSupervision = new Employee
                    {
                        FirstName = "John2",
                        SurName = "Doe2",
                        Email = "JohnDoe2@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20000,
                        BIGNumber = 200000,
                        IsStudent = false,
                    },
                    DateOfCreation = DateTime.Now.AddDays(5),
                    DateOfDischarge = DateTime.Now.AddDays(6),
                    PatientEmail = "JopDop2@mail.nl"
                }
            };

            return output;
        }

        [Fact]
        public void UpdateMedicalFile_StateUnderTest_ExpectedBehavior()
        {
            //arrange
            var files = getMedicalFileSample();
            mock.Setup(x => x.MedicalFiles).Returns(files.AsQueryable());
            var newFile = files[0];

            var controller = new MedicalFileController(mock.Object, mockEmployee.Object, mockPatient.Object, mockTreatment.Object, mockNotes.Object, mockAppointments.Object, mockGraphQLClient.Object, mockAvailability.Object, mockPracticeRoom.Object);

            var editedFile = newFile;
            editedFile.Description = "Edited Description";


            // Act
            var actionResult = controller.Edit(newFile.Id, newFile);

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(editedFile.Description, mock.Object.MedicalFiles.FirstOrDefault(X => X.Id == 1).Description);
        }

        [Fact]
        public void GetMedicalFileByEmail_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
