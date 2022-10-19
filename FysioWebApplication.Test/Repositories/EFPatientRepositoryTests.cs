using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFPatientRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFPatientRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFPatientRepository CreateEFPatientRepository()
        {
            return new EFPatientRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPatientRepository = this.CreateEFPatientRepository();

            // Act
            var result = eFPatientRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetPatient_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPatientRepository = this.CreateEFPatientRepository();
            int id = 0;

            // Act
            var result = eFPatientRepository.GetPatient(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdatePatient_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPatientRepository = this.CreateEFPatientRepository();
            int id = 0;
            Patient patient = null;

            // Act
            eFPatientRepository.UpdatePatient(
                id,
                patient);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddPatient_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPatientRepository = this.CreateEFPatientRepository();
            Patient patient = null;

            // Act
            eFPatientRepository.AddPatient(
                patient);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
