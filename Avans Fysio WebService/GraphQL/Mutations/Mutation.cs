using Avans_Fysio_WebService.GraphQL.Extensions;
using Avans_Fysio_WebService.GraphQL.Mutations.Payloads;
using Core.DomainModel;
using EFFysioData.DAL;
using HotChocolate;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.GraphQL.Mutations
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddDiagnosisPayload> AddDiagnosisAsync(
            Diagnosis input,
            [Service] FysioCodeDbContext context)
        {
            var diagnosis = new Diagnosis
            {
                Code = input.Code,
                BodyLocation = input.BodyLocation,
                Pathology = input.Pathology
            };

            context.Diagnoses.Add(diagnosis);
            await context.SaveChangesAsync();

            return new AddDiagnosisPayload(diagnosis);
        }

        [UseApplicationDbContext]
        public async Task<AddTreatmentPayload> AddTreatmentAsync(
            Treatment input,
            [Service] FysioCodeDbContext context)
        {
            var treatment = new Treatment
            {
                Code = input.Code,
                ExplanationRequired = input.ExplanationRequired,
                Description = input.Description,
            };

            context.Treatments.Add(treatment);
            await context.SaveChangesAsync();

            return new AddTreatmentPayload(treatment);
        }

    }
}
