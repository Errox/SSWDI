using Avans_Fysio_WebService.GraphQL.Extensions;
using Fysio_Codes.DAL;
using Fysio_Codes.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }

}
