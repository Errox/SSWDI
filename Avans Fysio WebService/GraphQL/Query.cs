using Avans_Fysio_WebService.Models;
using Fysio_Codes.DAL;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Filters;
using Fysio_Codes.Models;
using System.Linq;
using Avans_Fysio_WebService.GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

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
