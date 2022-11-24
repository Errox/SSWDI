using Avans_Fysio_WebService.GraphQL.Extensions;
using Core.DomainModel;
using EFFysioData.DAL;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.GraphQL
{
    public class Query
    {

        // Pagination if needed.
        //[UsePaging]
        //Using this annotation we're essentially applying a middleware to the field resolver.
        [UseApplicationDbContext]
        [UseFiltering]
        public Task<List<Diagnosis>> GetDiagnoses([ScopedService] FysioCodeDbContext context) =>
            context.Diagnoses.ToListAsync();

        // Pagination if needed.
        //[UsePaging]
        // Using this annotation we're essentially applying a middleware to the field resolver.
        [UseApplicationDbContext]
        [UseFiltering]
        public Task<List<Treatment>> GetTreatments([ScopedService] FysioCodeDbContext context) =>
            context.Treatments.ToListAsync();

        [UseApplicationDbContext]
        public Task<Treatment> GetTreatmentByCode([ScopedService] FysioCodeDbContext context, string code) =>
            context.Treatments.Where(treatment => treatment.Code == code).FirstOrDefaultAsync();

        [UseApplicationDbContext]
        public Task<Diagnosis> GetDiagnosesByCode([ScopedService] FysioCodeDbContext context, int id) =>
            context.Diagnoses.Where(diagnosis => diagnosis.Id == id).FirstOrDefaultAsync();

    }

}
