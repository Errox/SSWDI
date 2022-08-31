using Avans_Fysio_WebService.GraphQL.Extensions;
using Avans_Fysio_WebService.GraphQL.Mutations.Payloads;
using Avans_Fysio_WebService.Models;
using Fysio_Codes.DAL;
using Fysio_Codes.Models;
using HotChocolate;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.GraphQL.Mutations
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddDiagnosisPayload> AddDiagnosisAsync(
            AddDiagnosisPayload input,
            [Service] FysioCodeDbContext context)
        {
            var diagnosis = new Diagnosis
            {
                Code = input.Diagnosis.Code,
                BodyLocation = input.Diagnosis.BodyLocation,
                Pathology = input.Diagnosis.Pathology
            };

            context.Diagnoses.Add(diagnosis);
            await context.SaveChangesAsync();

            return new AddDiagnosisPayload(diagnosis);
        }

    }
}
