using Fysio_WebApplication.Controllers;
using Library.core.Model;
using Library.Domain.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FysioWebApplication.Test.Controllers
{
    public class TreatmentPlanControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ITreatmentPlanRepository> mockTreatmentPlanRepository;
        private Mock<IEmployeeRepository> mockEmployeeRepository;

        public TreatmentPlanControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTreatmentPlanRepository = this.mockRepository.Create<ITreatmentPlanRepository>();
            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>();
        }

        private TreatmentPlanController CreateTreatmentPlanController()
        {
            return new TreatmentPlanController(
                this.mockTreatmentPlanRepository.Object,
                this.mockEmployeeRepository.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var treatmentPlanController = this.CreateTreatmentPlanController();

            // Act
            var result = treatmentPlanController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public async Task DetailsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var treatmentPlanController = this.CreateTreatmentPlanController();
            int id = 0;

            // Act
            var result = await treatmentPlanController.DetailsAsync(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var treatmentPlanController = this.CreateTreatmentPlanController();

            // Act
            var result = treatmentPlanController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var treatmentPlanController = this.CreateTreatmentPlanController();
            TreatmentPlan collection = null;

            // Act
            var result = treatmentPlanController.Create(
                collection);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var treatmentPlanController = this.CreateTreatmentPlanController();
            int id = 0;

            // Act
            var result = treatmentPlanController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var treatmentPlanController = this.CreateTreatmentPlanController();
            int id = 0;
            TreatmentPlan collection = null;

            // Act
            var result = treatmentPlanController.Edit(
                id,
                collection);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
