using Core.DomainModel;
using Core.Enums;
using DomainServices.Repositories;
using DomainServices.Services;
using Moq;
using Services;

namespace BusinessRules
{
    public class BusinessRule6
    {

        [Fact]
        public void Test_AppointmentCanBeDeletedBefore24Hours_ExpectedBehavior()
        {
            Mock<IAppointmentsRepository> appointmentRepository = new Mock<IAppointmentsRepository>();

            IAppointmentsService appoinmentService = new AppointmentService(appointmentRepository.Object);

            Appointment appointment = new Appointment
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
                    StartAvailability = DateTime.Now.AddDays(-1).AddMinutes(60),
                    StopAvailability = DateTime.Now.AddDays(-1).AddMinutes(90),
                    IsAvailable = true
                },
            };

            appointmentRepository.Setup(e => e.FindByID(appointment.Id))
                .Returns(appointment);

            Appointment appointmentToBeRemoved = appoinmentService.FindByID(appointment.Id);


            // Act
            Action act = () => appoinmentService.Remove(appointment);

            //assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.Equal("Can't remove Appointment when it's 24 hours before appointment.", exception.Message);

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

    }
}