using Avans_Fysio_WebService.Models;
using HotChocolate;
using HotChocolate.Types;
using MainLibrary.DomainModel;
using System.Linq;

namespace Avans_Fysio_WebService.GraphQL
{
    public class Query
    {
        //[UsePaging]
        public IQueryable<Diagnosis> GetDiagnoses([Service] WebServiceDbContext context) =>
            context.Diagnoses.OrderBy(t => t.Id);
        //[UsePaging]
        public IQueryable<Treatment> GetTreatments([Service] WebServiceDbContext context) =>
            context.Treatments.OrderBy(t => t.Id);
    }

}
