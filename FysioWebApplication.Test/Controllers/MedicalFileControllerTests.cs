using Fysio_WebApplication.Controllers;
using Library.core.Model;
using Library.Domain.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FysioWebApplication.Test.Controllers
{
    public class MedicalFileControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IMedicalFileRepository> mockMedicalFileRepository;
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<IPatientRepository> mockPatientRepository;
        private Mock<ITreatmentPlanRepository> mockTreatmentPlanRepository;
        private Mock<INotesRepository> mockNotesRepository;
        private Mock<IPracticeRoomRepository> mockPracticeRoomRepository;

        public MedicalFileControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMedicalFileRepository = this.mockRepository.Create<IMedicalFileRepository>();
            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>();
            this.mockPatientRepository = this.mockRepository.Create<IPatientRepository>();
            this.mockTreatmentPlanRepository = this.mockRepository.Create<ITreatmentPlanRepository>();
            this.mockNotesRepository = this.mockRepository.Create<INotesRepository>();
            this.mockPracticeRoomRepository = this.mockRepository.Create<IPracticeRoomRepository>();
        }

        private MedicalFileController CreateMedicalFileController()
        {
            return new MedicalFileController(
                this.mockMedicalFileRepository.Object,
                this.mockEmployeeRepository.Object,
                this.mockPatientRepository.Object,
                this.mockTreatmentPlanRepository.Object,
                this.mockNotesRepository.Object,
                this.mockPracticeRoomRepository.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();

            // Act
            var result = medicalFileController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void IndexPersonalSupervise_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();

            // Act
            var result = medicalFileController.IndexPersonalSupervise();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void IndexPersonalTherapist_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();

            // Act
            var result = medicalFileController.IndexPersonalTherapist();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public async Task DetailsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;

            // Act
            var result = await medicalFileController.DetailsAsync(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;

            // Act
            var result = medicalFileController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;
            MedicalFile collection = null;

            // Act
            var result = medicalFileController.Edit(
                id,
                collection);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Notes_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;

            // Act
            var result = medicalFileController.Notes(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void NotesNew_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;

            // Act
            var result = medicalFileController.NotesNew(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void NotesNew_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;
            Note newNote = null;

            // Act
            var result = medicalFileController.NotesNew(
                id,
                newNote);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void TreatmentPlan_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;

            // Act
            var result = medicalFileController.TreatmentPlan(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void TreatmentPlanNew_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;

            // Act
            var result = medicalFileController.TreatmentPlanNew(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void TreatmentPlanNew_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int id = 0;
            TreatmentPlan plan = null;

            // Act
            var result = medicalFileController.TreatmentPlanNew(
                id,
                plan);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddRoomTreatment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int file = 0;
            int id = 0;

            // Act
            var result = medicalFileController.AddRoomTreatment(
                file,
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddRoomTreatment_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var medicalFileController = this.CreateMedicalFileController();
            int file = 0;
            int treatment = 0;
            PracticeRoom Room = null;

            // Act
            var result = medicalFileController.AddRoomTreatment(
                file,
                treatment,
                Room);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
