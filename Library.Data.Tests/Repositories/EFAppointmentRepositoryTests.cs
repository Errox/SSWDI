using Core.DomainModel;
using Core.Enums;
using DomainServices.Repositories;
using Fysio_WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Library.Data.Tests.Repositories
{
    public class EFAppointmentRepositoryTests
    {
        private Mock<IAppointmentsRepository> mock = new Mock<IAppointmentsRepository>();
        private Mock<IEmployeeRepository> mockEmployee = new Mock<IEmployeeRepository>();
        private Mock<IPatientRepository> mockPatient = new Mock<IPatientRepository>();
        private Mock<IAvailabilityRepository> mockAvailability = new Mock<IAvailabilityRepository>();

        public EFAppointmentRepositoryTests()
        {
            mock = new Mock<IAppointmentsRepository>();
            mockEmployee = new Mock<IEmployeeRepository>();
            mockPatient = new Mock<IPatientRepository>();
            mockAvailability = new Mock<IAvailabilityRepository>();
        }


        [Fact]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var Appointment = getAppointmentSample();
            mock.Setup(x => x.Appointments).Returns(Appointment.AsQueryable());
            var controller = new AppointmentController(mockAvailability.Object, mockEmployee.Object, mockPatient.Object, mock.Object);

            // Act
            var actionResult = controller.Index();
            var result = actionResult as ViewResult;
            var model = result.Model as IEnumerable<Appointment>;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(getAppointmentSample().Count(), model.Count());
        }

        private List<Appointment> getAppointmentSample()
        {
            List<Appointment> output = new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    Employee = new Employee
                    {
                        FirstName = "John2",
                        SurName = "Doe2",
                        Email = "JohnDoe2@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20000,
                        BIGNumber = 200000,
                        IsStudent = false,
                    },
                    Patient = new Patient
                    {
                        FirstName = "John2",
                        SurName = "Doe2",
                        Email = "Patient@mail.com",
                        PhoneNumber = "0612345678",
                        IsStudent = false,
                        IdNumber = 20,
                        DateOfBirth = DateTime.Now.AddYears(-25),
                        Gender = EnumGender.Gender.Other,
                    },
                    TimeSlot = new Availability
                    {
                        Id = 2,
                        Employee = new Employee
                        {
                            FirstName = "John2",
                            SurName = "Doe2",
                            Email = "JohnDoe2@mail.nl",
                            PhoneNumber = "0612345678",
                            WorkerNumber = 20000,
                            BIGNumber = 200000,
                            IsStudent = false,
                        },
                        StartAvailability = DateTime.Now.AddDays(2),
                        StopAvailability = DateTime.Now.AddDays(2).AddMinutes(30),
                        IsAvailable = true
                    },
                },
                new Appointment
                {
                    Id = 2,
                    Employee = new Employee
                    {
                        FirstName = "John",
                        SurName = "Doe",
                        Email = "JohnDoe@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20001,
                        BIGNumber = 200001,
                        IsStudent = false,
                    },
                    Patient = new Patient
                    {
                        FirstName = "John",
                        SurName = "Doe",
                        Email = "Patient2@mail.com",
                        PhoneNumber = "0612345678",
                        IsStudent = false,
                        IdNumber = 20,
                        DateOfBirth = DateTime.Now.AddYears(-23),
                        Gender = EnumGender.Gender.Male,
                    },
                    TimeSlot = new Availability
                    {
                        Id = 1,
                        Employee = new Employee
                        {
                            FirstName = "John",
                            SurName = "Doe",
                            Email = "JohnDoe@mail.nl",
                            PhoneNumber = "0612345678",
                            WorkerNumber = 20000,
                            BIGNumber = 200000,
                            IsStudent = false,
                        },
                        StartAvailability = DateTime.Now.AddDays(3),
                        StopAvailability = DateTime.Now.AddDays(3).AddMinutes(30),
                        IsAvailable = true
                    },
                },
            };

            return output;
        }

        [Fact]
        public void UpdateAppointment_StateUnderTest_ExpectedBehavior()
        {
            //arrange
            var files = getAppointmentSample();
            mock.Setup(x => x.Appointments).Returns(files.AsQueryable());
            var newFile = files[0];

            var controller = new AppointmentController(mockAvailability.Object, mockEmployee.Object, mockPatient.Object, mock.Object);

            var editedFile = newFile;
            editedFile.TimeSlot = new Availability
            {
                Id = 1,
                Employee = new Employee
                {
                    FirstName = "John",
                    SurName = "Doe",
                    Email = "JohnDoe@mail.nl",
                    PhoneNumber = "0612345678",
                    WorkerNumber = 20000,
                    BIGNumber = 200000,
                    IsStudent = false,
                },
                StartAvailability = DateTime.Now.AddDays(3),
                StopAvailability = DateTime.Now.AddDays(3).AddMinutes(30),
                IsAvailable = false
            };


            // Act
            var actionResult = controller.Edit(newFile.Id, newFile);

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(editedFile.TimeSlot.IsAvailable, mock.Object.Appointments.FirstOrDefault(X => X.Id == 1).TimeSlot.IsAvailable);
        }

        [Fact]
        public void GetAppointmentByEmail_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            // Act

            // Assert
        }

    }
}
