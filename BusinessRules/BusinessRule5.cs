using Core.DomainModel;
using Core.Enums;
using DomainServices.Repositories;
using DomainServices.Services;
using Moq;
using NuGet.Frameworks;
using Services;
using System.ComponentModel.DataAnnotations;

namespace BusinessRules
{
    public class BusinessRule5
    {
        [Fact]
        public void AgeOfPatientCantBeLowerThen16()
        {
            // arrange
            Mock<IPatientRepository> patientRepository = new Mock<IPatientRepository>();

            IPatientService patientService = new PatientService(patientRepository.Object);

            Patient patient = new Patient
            {
                FirstName = "John2",
                SurName = "Doe2",
                Email = "Patient@mail.com",
                PhoneNumber = "0612345678",
                IsStudent = false,
                IdNumber = 20,
                DateOfBirth = DateTime.Now.AddYears(-15),
                Gender = EnumGender.Gender.Other,
            };

            // act
            bool validationResults = ValidateModel(patient).Any(
                v => v.ErrorMessage.Contains("You must be at least 16 years old to register."));

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