using Avans_Fysio_WebService.Controllers;
using Avans_Fysio_WebService.Models;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Avans_Fysio_WebService_Tests
{
    public class TestTreatmentRepo
    {
        [Fact]
        // Test if it's possible to setup and return treatments with the mock.
        public void Test1()
        {
            // Arrange
            Mock<ITreatmentRepository> mock = new Mock<ITreatmentRepository>();
            mock.Setup(m => m.Treatments).Returns((new Treatment[]
            {
                new Treatment { Code = "1000", Description = "Individuele zitting reguliere fysiotherapie", ExplanationRequired = true},
                new Treatment { Code = "F1000", Description = "Individuele zitting reguliere fysiotherapie met toeslag voor behandeling in een instelling", ExplanationRequired = false},
            }).AsQueryable<Treatment>());

            TreatmentController controller = new TreatmentController(mock.Object);
            // Act

        //IOrderedEnumerable<Treatment> resul =
        //        (controller.)


            // Assert
        }
    }
}
