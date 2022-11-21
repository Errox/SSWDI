using DomainServices.Repositories;
using EFFysioData.DAL;
using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace EFFysioData.Repositories
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
