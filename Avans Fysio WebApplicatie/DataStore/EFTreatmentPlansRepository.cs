using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Abstract.Repositories;
using Avans_Fysio_WebApplicatie.Data;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.DAL
{
    public class EFTreatmentPlansRepository : ITreatmentRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFTreatmentPlansRepository(WebApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<TreatmentPlan> TreatmentPlans => _context.TreatmentPlans;

        public void AddTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            _context.Add(treatmentPlan);
            _context.SaveChanges();
        }

        public IEnumerable<TreatmentPlan> FindAll()
        {
            return _context.TreatmentPlans;
        }

        public TreatmentPlan GetTreatmentPlan(int id)
        {
            return _context.TreatmentPlans.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            _context.SaveChanges();
        }
    }
}
