using DomainServices.Repositories;
using DomainServices.Services;
using Fysio_WebApplication.Controllers;
using Moq;

namespace FysioWebApplication.Test.Controllers
{
    public class AppointmentControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IAppointmentsService> mockAppointmentsService;
        private Mock<IAvailabilityService> mockAvailabilityService;
        private Mock<IEmployeeService> mockEmployeeService;
        private Mock<IPatientService> mockPatientService;

        public AppointmentControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAppointmentsService = this.mockRepository.Create<IAppointmentsService>();
            this.mockAvailabilityService = this.mockRepository.Create<IAvailabilityService>();
            this.mockEmployeeService = this.mockRepository.Create<IEmployeeService>();
            this.mockPatientService = this.mockRepository.Create<IPatientService>();
        }

        private AppointmentController CreateAppointmentController()
        {
            return new AppointmentController(
                this.mockAvailabilityService.Object,
                this.mockEmployeeService.Object,
                this.mockPatientService.Object,
                this.mockAppointmentsService.Object);
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
