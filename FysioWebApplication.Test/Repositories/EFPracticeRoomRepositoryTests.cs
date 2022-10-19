using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFPracticeRoomRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFPracticeRoomRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFPracticeRoomRepository CreateEFPracticeRoomRepository()
        {
            return new EFPracticeRoomRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddPracticeRoom_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPracticeRoomRepository = this.CreateEFPracticeRoomRepository();
            PracticeRoom practiceRoom = null;

            // Act
            eFPracticeRoomRepository.AddPracticeRoom(
                practiceRoom);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPracticeRoomRepository = this.CreateEFPracticeRoomRepository();

            // Act
            var result = eFPracticeRoomRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetPracticeRoom_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPracticeRoomRepository = this.CreateEFPracticeRoomRepository();
            int id = 0;

            // Act
            var result = eFPracticeRoomRepository.GetPracticeRoom(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdatePracticeRoom_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFPracticeRoomRepository = this.CreateEFPracticeRoomRepository();
            int id = 0;
            PracticeRoom practiceRoom = null;

            // Act
            eFPracticeRoomRepository.UpdatePracticeRoom(
                id,
                practiceRoom);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
