using Fysio_WebApplication.Controllers;
using Library.core.Model;
using Library.Domain.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Controllers
{
    public class PracticeRoomControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IPracticeRoomRepository> mockPracticeRoomRepository;

        public PracticeRoomControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPracticeRoomRepository = this.mockRepository.Create<IPracticeRoomRepository>();
        }

        private PracticeRoomController CreatePracticeRoomController()
        {
            return new PracticeRoomController(
                this.mockPracticeRoomRepository.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var practiceRoomController = this.CreatePracticeRoomController();

            // Act
            var result = practiceRoomController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var practiceRoomController = this.CreatePracticeRoomController();
            int id = 0;

            // Act
            var result = practiceRoomController.Details(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var practiceRoomController = this.CreatePracticeRoomController();

            // Act
            var result = practiceRoomController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var practiceRoomController = this.CreatePracticeRoomController();
            PracticeRoom practiceRoom = null;

            // Act
            var result = practiceRoomController.Create(
                practiceRoom);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var practiceRoomController = this.CreatePracticeRoomController();
            int id = 0;

            // Act
            var result = practiceRoomController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var practiceRoomController = this.CreatePracticeRoomController();
            int id = 0;
            PracticeRoom practiceRoom = null;

            // Act
            var result = practiceRoomController.Edit(
                id,
                practiceRoom);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
