using Fysio_Codes.Abstract;
using Fysio_Codes.DAL;
using Fysio_Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fysio_Codes.DataStore
{
    public class EFTreatmentRepository : ITreatmentRepository
    {
        private FysioCodeDbContext context;

        public EFTreatmentRepository(FysioCodeDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Treatment> Treatments => context.Treatments;

        public IEnumerable<Treatment> FindAll()
        {
            return context.Treatments;
        }

        public Treatment GetTreatment(string id)
        {
            return context.Treatments.Where(i => i.Code == id).FirstOrDefault();
        }
    }
}
