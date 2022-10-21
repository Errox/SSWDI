using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFAppointmentRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFAppointmentRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFAppointmentRepository CreateEFAppointmentRepository()
        {
            return new EFAppointmentRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFAppointmentRepository = this.CreateEFAppointmentRepository();

            // Act
            var result = eFAppointmentRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetAppointment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFAppointmentRepository = this.CreateEFAppointmentRepository();
            int id = 0;

            // Act
            var result = eFAppointmentRepository.GetAppointment(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void DeleteAppointment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFAppointmentRepository = this.CreateEFAppointmentRepository();
            int id = 0;

            // Act
            eFAppointmentRepository.DeleteAppointment(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdateAppointment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFAppointmentRepository = this.CreateEFAppointmentRepository();
            Appointment appointment = null;

            // Act
            eFAppointmentRepository.UpdateAppointment(
                appointment);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddAppointment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFAppointmentRepository = this.CreateEFAppointmentRepository();
            Appointment appointment = null;

            // Act
            eFAppointmentRepository.AddAppointment(
                appointment);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
