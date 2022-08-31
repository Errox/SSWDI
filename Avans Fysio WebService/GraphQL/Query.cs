using Avans_Fysio_WebService.Models;
using Fysio_Codes.DAL;
using HotChocolate;
using HotChocolate.Types;
using Fysio_Codes.Models;
using System.Linq;
using Avans_Fysio_WebService.GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.GraphQL
{
    public class Query
    {
        //[UsePaging]
        // Using this annotation we're essentially applying a middleware to the field resolver.
        [UseApplicationDbContext]
        public Task<List<Diagnosis>> GetDiagnoses([ScopedService] FysioCodeDbContext context) =>
            context.Diagnoses.ToListAsync();
        //[UsePaging]
        // Using this annotation we're essentially applying a middleware to the field resolver.
        [UseApplicationDbContext]
        public Task<List<Treatment>> GetTreatments([ScopedService] FysioCodeDbContext context) =>
            context.Treatments.ToListAsync();
    }

}
