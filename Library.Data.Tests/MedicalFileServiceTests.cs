using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Fysio_WebApplication.Controllers;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace Services.Test
{
    public class MedicalFileServiceTests
    {
        private Mock<IMedicalFileService> mock = new Mock<IMedicalFileService>();
        private Mock<IEmployeeService> mockEmployee = new Mock<IEmployeeService>();
        private Mock<IPatientService> mockPatient = new Mock<IPatientService>();
        private Mock<ITreatmentPlanService> mockTreatment = new Mock<ITreatmentPlanService>();
        private Mock<INotesService> mockNotes = new Mock<INotesService>();
        private Mock<IAppointmentsService> mockAppointments = new Mock<IAppointmentsService>();
        private Mock<IAvailabilityService> mockAvailability = new Mock<IAvailabilityService>();
        private Mock<IPracticeRoomService> mockPracticeRoom = new Mock<IPracticeRoomService>();
        private Mock<IGraphQLClient> mockGraphQLClient = new Mock<IGraphQLClient>();
        private Claim[] claims;

        public MedicalFileServiceTests()
        {
            mock = new Mock<IMedicalFileService>();
            mockEmployee = new Mock<IEmployeeService>();
            mockPatient = new Mock<IPatientService>();
            mockTreatment = new Mock<ITreatmentPlanService>();
            mockNotes = new Mock<INotesService>();
            mockAppointments = new Mock<IAppointmentsService>();
            mockAvailability = new Mock<IAvailabilityService>();
            mockPracticeRoom = new Mock<IPracticeRoomService>();
            mockGraphQLClient = new Mock<IGraphQLClient>();
        }


        [Fact(Skip= "Debug state")]
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
