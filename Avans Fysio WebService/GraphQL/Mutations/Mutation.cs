using Avans_Fysio_WebService.GraphQL.Mutations.Payloads;
using Avans_Fysio_WebService.Models;
using HotChocolate;
using MainLibrary.DomainModel;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.GraphQL.Mutations
{
    public class Mutation
    {
        public async Task<AddDiagnosisPayload> AddDiagnosisAsync(
            AddDiagnosisPayload input,
            [Service] WebServiceDbContext context)
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
