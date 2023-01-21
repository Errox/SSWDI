using Core.DomainModel;
using Core.Enums;
using DomainServices.Repositories;
using DomainServices.Services;
using Moq;
using Services;


namespace BusinessRules
{
    public class BusinessRule1
    {
        [Fact]
        public void AmountOfAppointmentsCantBeOverWritten()
        {
            // Arrange
            Mock<IMedicalFileRepository> medicalFileRepository = new Mock<IMedicalFileRepository>();
            Mock<IAppointmentsRepository> appointmentRepository = new Mock<IAppointmentsRepository>();
            Mock<IPatientRepository> patientRepository = new Mock<IPatientRepository>();

            IAppointmentsService appoinmentService = new AppointmentService(appointmentRepository.Object);
            List<TreatmentPlan> treatmentPlans = new List<TreatmentPlan>
            {
                new TreatmentPlan
                {
                    Id = 1,
                    Type = 1500,
                    PracticeRoom = new PracticeRoom
                    {
                        Id = 2,
                        Name = "Room: 200"
                    },
                    Particularities = " Particularities ",
                    TreatmentPerformedBy = new Employee
                    {
                        FirstName = "John2",
                        SurName = "Doe2",
                        Email = "JohnDoe2@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20000,
                        BIGNumber = 200000,
                        IsStudent = false,
                    },
                    TreatmentDate = new DateTime().AddDays(1),
                    AmountOfTreatmentsPerWeek = 1,
                }
            };

            Patient patient = new Patient
            {
                FirstName = "John2",
                SurName = "Doe2",
                Email = "Patient@mail.com",
                PhoneNumber = "0612345678",
                IsStudent = false,
                IdNumber = 20,
                DateOfBirth = DateTime.Now.AddYears(-25),
                Gender = EnumGender.Gender.Other,
                MedicalFile = new MedicalFile
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
                    PatientEmail = "JopDop2@mail.nl",
                    TreatmentPlans = treatmentPlans
                },
            };
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
                    Patient = patient,
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
                    }
                },
                new Appointment
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
                    Patient = patient,
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
                        StartAvailability = DateTime.Now.AddDays(-1).AddMinutes(90),
                        StopAvailability = DateTime.Now.AddDays(-1).AddMinutes(120),
                        IsAvailable = true
                    }
                }
            };
            Appointment newAppointment = new Appointment
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
                Patient = patient,
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
                    StartAvailability = DateTime.Now.AddDays(-1).AddMinutes(90),
                    StopAvailability = DateTime.Now.AddDays(-1).AddMinutes(120),
                    IsAvailable = true
                }
            };


            appointmentRepository.Setup(x => x.GetAppointment(output[0].Id)).Returns(output[0]);


            // act
            Action act = () => appoinmentService.AddNewAppointment(patient, newAppointment);


            // assert
            // You can't create more appointments then the treatment prescribes.");
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);

            Assert.Equal("You can't create more appointments then the treatment prescribes.", exception.Message);

        }
    }
}