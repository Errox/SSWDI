using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFMedicalFileRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFMedicalFileRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFMedicalFileRepository CreateEFMedicalFileRepository()
        {
            return new EFMedicalFileRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFMedicalFileRepository = this.CreateEFMedicalFileRepository();

            // Act
            var result = eFMedicalFileRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetMedicalFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFMedicalFileRepository = this.CreateEFMedicalFileRepository();
            int id = 0;

            // Act
            var result = eFMedicalFileRepository.GetMedicalFile(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdateMedicalFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFMedicalFileRepository = this.CreateEFMedicalFileRepository();
            int id = 0;
            MedicalFile medicalFile = null;

            // Act
            eFMedicalFileRepository.UpdateMedicalFile(
                id,
                medicalFile);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddMedicalFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFMedicalFileRepository = this.CreateEFMedicalFileRepository();
            MedicalFile medicalFile = null;

            // Act
            eFMedicalFileRepository.AddMedicalFile(
                medicalFile);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
