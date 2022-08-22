using FysioWebService.Database;
using HotChocolate;
using MainLibrary.DomainModel;
using System.Linq;

namespace FysioWebService.GraphQL
{
    public class Query
    {
        public IQueryable<Diagnosis> GetDiagnoses([Service] FysioWebDbContext context) =>
            context.Diagnoses;
        public IQueryable<Treatment> GetTreatments([Service] FysioWebDbContext context) =>
            context.Treatments;
        //public IQueryable<Treatment> GetTreatments([Service] FysioWebDbContext context, int Id) =>
        //    context.Treatments.FirstOrDefault(Id);
    }

}
