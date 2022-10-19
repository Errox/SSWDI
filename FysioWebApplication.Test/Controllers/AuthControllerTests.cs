using Fysio_WebApplication.Controllers;
using Library.Domain.Repositories;
using Library.core.Model;
using Library.core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FysioWebApplication.Test.Controllers
{
    public class AuthControllerTests
    {
        private MockRepository mockRepository;

        private Mock<UserManager<ApplicationUser>> mockUserManager;
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<IPatientRepository> mockPatientRepository;
        private Mock<ILogger<LoginModel>> mockLogger;
        private Mock<SignInManager<ApplicationUser>> mockSignInManager;

        public AuthControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUserManager = this.mockRepository.Create<UserManager<ApplicationUser>>();
            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>();
            this.mockPatientRepository = this.mockRepository.Create<IPatientRepository>();
            this.mockLogger = this.mockRepository.Create<ILogger<LoginModel>>();
            this.mockSignInManager = this.mockRepository.Create<SignInManager<ApplicationUser>>();
        }

        private AuthController CreateAuthController()
        {
            return new AuthController(
                this.mockUserManager.Object,
                this.mockEmployeeRepository.Object,
                this.mockPatientRepository.Object,
                this.mockLogger.Object,
                this.mockSignInManager.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void Login_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authController = this.CreateAuthController();
            string returnUrl = null;

            // Act
            var result = authController.Login(
                returnUrl);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public async Task Login_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var authController = this.CreateAuthController();
            LoginModel model = null;

            // Act
            var result = await authController.Login(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public async Task Logout_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authController = this.CreateAuthController();
            string returnUrl = null;

            // Act
            var result = await authController.Logout(
                returnUrl);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void RegisterEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authController = this.CreateAuthController();
            string returnUrl = null;

            // Act
            var result = authController.RegisterEmployee(
                returnUrl);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void RegisterPatient_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authController = this.CreateAuthController();
            string returnUrl = null;

            // Act
            var result = authController.RegisterPatient(
                returnUrl);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public async Task RegisterEmployee_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var authController = this.CreateAuthController();
            RegisterEmployeeModel model = null;

            // Act
            var result = await authController.RegisterEmployee(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public async Task RegisterPatient_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var authController = this.CreateAuthController();
            RegisterPatientModel model = null;

            // Act
            var result = await authController.RegisterPatient(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authController = this.CreateAuthController();

            // Act
            var result = authController.Error();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void AccountIndex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authController = this.CreateAuthController();

            // Act
            var result = authController.AccountIndex();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
