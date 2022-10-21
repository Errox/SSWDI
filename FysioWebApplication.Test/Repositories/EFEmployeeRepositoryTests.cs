using Library.core.Model;
using Library.Data.Dal;
using Library.Data.Repositories;
using Moq;
using System;
using Xunit;

namespace FysioWebApplication.Test.Repositories
{
    public class EFEmployeeRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EFEmployeeRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EFEmployeeRepository CreateEFEmployeeRepository()
        {
            return new EFEmployeeRepository(
                this.mockApplicationDbContext.Object);
        }

        [Fact(Skip = "Not Build Yet")]
        public void AddEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFEmployeeRepository = this.CreateEFEmployeeRepository();
            Employee employee = null;

            // Act
            eFEmployeeRepository.AddEmployee(
                employee);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFEmployeeRepository = this.CreateEFEmployeeRepository();

            // Act
            var result = eFEmployeeRepository.FindAll();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void GetEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFEmployeeRepository = this.CreateEFEmployeeRepository();
            string id = null;

            // Act
            var result = eFEmployeeRepository.GetEmployee(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact(Skip = "Not Build Yet")]
        public void UpdateEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFEmployeeRepository = this.CreateEFEmployeeRepository();
            Employee employee = null;

            // Act
            eFEmployeeRepository.UpdateEmployee(
                employee);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
