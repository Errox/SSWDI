using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;

namespace Fysio_WebApplication.DAL
{
    public class EFTreatmentPlansRepository : ITreatmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EFTreatmentPlansRepository(ApplicationDbContext ctx)
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
