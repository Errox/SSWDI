using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.Models
{
    public class EFTreatmentRepository : ITreatmentRepository
    {
        private WebServiceDbContext context;

        public EFTreatmentRepository(WebServiceDbContext ctx)
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
