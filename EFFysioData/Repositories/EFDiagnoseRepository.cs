using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;
using System.Collections.Generic;
using System.Linq;

namespace EFFysioData.Repositories
{
    public class EFDiagnoseRepository : IDiagnosesRepository
    {
        private FysioCodeDbContext context;

        public EFDiagnoseRepository(FysioCodeDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Diagnosis> Diagnoses => context.Diagnoses;

        public IEnumerable<Diagnosis> FindAll()
        {
            return context.Diagnoses;
        }

        public Diagnosis GetDiagnosis(int id)
        {
            return context.Diagnoses.FirstOrDefault(i => i.Code == id);
        }
    }
}
