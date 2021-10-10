using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.Models
{
    public class EFDiagnosesRepository : IDiagnosesRepository
    {
        private WebServiceDbContext context;

        public EFDiagnosesRepository(WebServiceDbContext ctx)
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
            return context.Diagnoses.Where(i => i.Code == id).FirstOrDefault();
        }
    }
}
