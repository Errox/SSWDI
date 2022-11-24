using Core.DomainModel;
using DomainServices.Repositories;
using Fysio_WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Library.Data.Tests.Repositories
{
    public class EFNotesRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;
        private readonly Mock<INotesRepository> noteRepo;

        public EFNotesRepositoryTests()
        {
            noteRepo = new Mock<INotesRepository>();
        }

        [Fact]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var note = getSampleNotes();
            noteRepo.Setup(x => x.FindAll()).Returns(note);

            var controller = new NoteController(noteRepo.Object);

            // Act
            var actionResult = controller.Index();
            var result = actionResult as ViewResult;
            var model = result.Model as IEnumerable<Note>;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(getSampleNotes().Count(), model.Count());
        }

        [Fact]
        public void UpdateNote_StateUnderTest_ExpectedBehavior()
        {
            //arrange
            var notes = getSampleNotes();
            noteRepo.Setup(x => x.Notes).Returns(notes.AsQueryable());
            var newNote = notes[0];

            var controller = new NoteController(noteRepo.Object);

            var editedNote = newNote;
            editedNote.Description = "New Description";

            // Act
            var actionResult = controller.Edit(newNote.Id, newNote);

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(editedNote.Description, noteRepo.Object.Notes.FirstOrDefault(X => X.Id == 1).Description);
        }

        private List<Note> getSampleNotes()
        {
            List<Note> output = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Description = "This is a note",
                    CreatedUtc = DateTime.Now.AddMinutes(-5),
                    Employee = new Employee
                    {
                        FirstName = "John",
                        SurName = "Doe",
                        Email = "JohnDoe@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20000,
                        BIGNumber = 200000,
                        IsStudent = false,
                    },
                    OpenForPatient = true
                },
                new Note
                {
                    Id = 2,
                    Description = "This is a second note",
                    CreatedUtc = DateTime.Now.AddMinutes(-2),
                    Employee = new Employee
                    {
                        FirstName = "Sam",
                        SurName = "Doe",
                        Email = "SamDoe@mail.nl",
                        PhoneNumber = "0612345678",
                        WorkerNumber = 20001,
                        BIGNumber = 200002,
                        IsStudent = true,
                    },
                    OpenForPatient = true
                }
            };
            return output;
        }
    }
}
