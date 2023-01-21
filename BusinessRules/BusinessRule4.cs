using Core.DomainModel;
using Core.Enums;
using DomainServices.Repositories;
using DomainServices.Services;
using Moq;
using Services;

namespace BusinessRules
{
    public class BusinessRule4
    {
        [Fact]
        public void DescriptionOnTreatmentPlanIsMandetoryIfTreatmentAsksForIt()
        {
            // arrange 
            Mock<ITreatmentPlanRepository> treatmentplanRepository = new Mock<ITreatmentPlanRepository>();
            Mock<ITreatmentService> treatmentService= new Mock<ITreatmentService>();
            // Get TreatmentPlan service
            ITreatmentPlanService treatmentPlanService = new TreatmentPlanService(treatmentplanRepository.Object);
            // Make a treatmentplan

            TreatmentPlan treatmentPlan = new TreatmentPlan
            {
                Id = 1,
                Type = 1500,
                PracticeRoom = new PracticeRoom
                {
                    Id = 2,
                    Name = "Room: 200"
                },
                Particularities = " Particularities ",
                TreatmentPerformedBy = new Employee
                {
                    FirstName = "John2",
                    SurName = "Doe2",
                    Email = "JohnDoe2@mail.nl",
                    PhoneNumber = "0612345678",
                    WorkerNumber = 20000,
                    BIGNumber = 200000,
                    IsStudent = false,
                },
                TreatmentDate = new DateTime().AddDays(1),
                AmountOfTreatmentsPerWeek = 1,
            };

            Treatment treatment = new Treatment {
                Id = 1,
                Description = "Description of treatment",
                Code = "1500",
                ExplanationRequired = true,
            };



            // Act
            Action act = () => treatmentPlanService.AddTreatmentToTreatmentPlan(treatmentPlan, treatment);
            // TreatmentPlan Service . add AddTreatmentPlan

            // Check for exception thrown
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);

            Assert.Equal("TreatmentPlan Needs a description when treatments ask for description.", exception.Message);

        }
    }
}