using DomainServices.Repositories;
using Fysio_WebApplication.Controllers;
using Moq;

namespace FysioWebApplication.Test.Controllers
{
    public class AppointmentControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IAppointmentsRepository> mockAppointmentsRepository;
        private Mock<IAvailabilityRepository> mockAvailabilityRepository;
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<IPatientRepository> mockPatientRepository;

        public AppointmentControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAppointmentsRepository = this.mockRepository.Create<IAppointmentsRepository>();
            this.mockAvailabilityRepository = this.mockRepository.Create<IAvailabilityRepository>();
            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>();
            this.mockPatientRepository = this.mockRepository.Create<IPatientRepository>();
        }

        private AppointmentController CreateAppointmentController()
        {
            return new AppointmentController(
                this.mockAvailabilityRepository.Object,
                this.mockEmployeeRepository.Object,
                this.mockPatientRepository.Object,
                this.mockAppointmentsRepository.Object);
        }

        [Fact]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

    }
}
