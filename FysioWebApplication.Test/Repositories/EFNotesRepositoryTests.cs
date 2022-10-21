using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFNotesRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFNotesRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFNotesRepository CreateEFNotesRepository()
        {
            return new EFNotesRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFNotesRepository = this.CreateEFNotesRepository();

            // Act
            var result = eFNotesRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetNote_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFNotesRepository = this.CreateEFNotesRepository();
            int id = 0;

            // Act
            var result = eFNotesRepository.GetNote(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdateNote_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFNotesRepository = this.CreateEFNotesRepository();
            int id = 0;
            Note note = null;

            // Act
            eFNotesRepository.UpdateNote(
                id,
                note);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddNote_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFNotesRepository = this.CreateEFNotesRepository();
            Note note = null;

            // Act
            eFNotesRepository.AddNote(
                note);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
