using Fysio_WebApplication.Controllers;
using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Controllers
{
    public class NoteControllerTests
    {
        private MockRepository mockRepository;

        private Mock<INotesRepository> mockNotesRepository;

        public NoteControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockNotesRepository = this.mockRepository.Create<INotesRepository>();
        }

        private NoteController CreateNoteController()
        {
            return new NoteController(
                this.mockNotesRepository.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var noteController = this.CreateNoteController();

            // Act
            var result = noteController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var noteController = this.CreateNoteController();

            // Act
            var result = noteController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var noteController = this.CreateNoteController();
            IFormCollection collection = null;

            // Act
            var result = noteController.Create(
                collection);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var noteController = this.CreateNoteController();
            int id = 0;

            // Act
            var result = noteController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var noteController = this.CreateNoteController();
            int id = 0;
            Note note = null;

            // Act
            var result = noteController.Edit(
                id,
                note);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
