using Core.DomainModel;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessRules
{
    public class BusinessRule2
    {
        [Fact]
        public void Test1()
        {
            // Since it's a requirment for the timeslot to be set for a appointment.
            // We need to test it if we can add a appointment without a timeslot.

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
                    DateOfBirth = DateTime.Now.AddYears(-19),
                    Gender = EnumGender.Gender.Other,
                }
            };


            // act
            bool validationResults = ValidateModel(appointment).Any(
                v => v.MemberNames.Contains("TimeSlot") &&
                     v.ErrorMessage.Contains("required"));

            // assert
            Assert.True(validationResults);


        }
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

    }
}