using Fysio_WebApplication.Controllers;
using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Controllers
{
    public class PatientControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IPatientRepository> mockPatientRepository;
        private Mock<IMedicalFileRepository> mockMedicalFileRepository;
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<IAuthorizationService> mockAuthorizationService;

        public PatientControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPatientRepository = this.mockRepository.Create<IPatientRepository>();
            this.mockMedicalFileRepository = this.mockRepository.Create<IMedicalFileRepository>();
            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>();
            this.mockAuthorizationService = this.mockRepository.Create<IAuthorizationService>();
        }

        private PatientController CreatePatientController()
        {
            return new PatientController(
                this.mockPatientRepository.Object,
                this.mockMedicalFileRepository.Object,
                this.mockEmployeeRepository.Object,
                this.mockAuthorizationService.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();

            // Act
            var result = patientController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void DetailsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int id = 0;

            // Act
            var result = patientController.DetailsAsync(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();

            // Act
            var result = patientController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            Patient pool = null;

            // Act
            var result = patientController.Create(
                pool);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int id = 0;

            // Act
            var result = patientController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int id = 0;
            Patient patient = null;

            // Act
            var result = patientController.Edit(
                id,
                patient);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void MedicalFileNew_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int patientId = 0;

            // Act
            var result = patientController.MedicalFileNew(
                patientId);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void MedicalFileNew_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int id = 0;
            MedicalFile file = null;

            // Act
            var result = patientController.MedicalFileNew(
                id,
                file);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
