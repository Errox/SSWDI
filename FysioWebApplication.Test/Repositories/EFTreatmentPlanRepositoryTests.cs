using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFTreatmentPlanRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFTreatmentPlanRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFTreatmentPlanRepository CreateEFTreatmentPlanRepository()
        {
            return new EFTreatmentPlanRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddTreatmentPlan_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFTreatmentPlanRepository = this.CreateEFTreatmentPlanRepository();
            TreatmentPlan treatmentPlan = null;

            // Act
            eFTreatmentPlanRepository.AddTreatmentPlan(
                treatmentPlan);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFTreatmentPlanRepository = this.CreateEFTreatmentPlanRepository();

            // Act
            var result = eFTreatmentPlanRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetTreatmentPlan_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFTreatmentPlanRepository = this.CreateEFTreatmentPlanRepository();
            int id = 0;

            // Act
            var result = eFTreatmentPlanRepository.GetTreatmentPlan(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdateTreatmentPlan_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFTreatmentPlanRepository = this.CreateEFTreatmentPlanRepository();
            int id = 0;
            TreatmentPlan treatmentPlan = null;

            // Act
            eFTreatmentPlanRepository.UpdateTreatmentPlan(
                id,
                treatmentPlan);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
