using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TreatmentPlanService : ITreatmentPlanService
    {
        private readonly ITreatmentPlanRepository _treatmentPlanRepository;

        public TreatmentPlanService(ITreatmentPlanRepository treatmentPlanRepository)
        {
            _treatmentPlanRepository = treatmentPlanRepository;
        }
        public IQueryable<TreatmentPlan> TreatmentPlans => _treatmentPlanRepository.TreatmentPlans;

        public void Add(TreatmentPlan entity)
        {
            _treatmentPlanRepository.Add(entity);
        }

        public void AddTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            _treatmentPlanRepository.Add(treatmentPlan);
        }

        public TreatmentPlan FindByID(int ID)
        {
            return _treatmentPlanRepository.GetTreatmentPlan(ID);
        }

        public IEnumerable<TreatmentPlan> GetAll()
        {
            return _treatmentPlanRepository.GetAll();
        }

        public TreatmentPlan GetTreatmentPlan(int id)
        {
            return _treatmentPlanRepository.GetTreatmentPlan(id);
        }

        public void Remove(TreatmentPlan entity)
        {
            _treatmentPlanRepository.Remove(entity);
        }

        public void Update(int id, TreatmentPlan entity)
        {
            _treatmentPlanRepository.Update(id, entity);
        }

        public void UpdateTreatmentPlan(int id, TreatmentPlan treatmentPlan)
        {
            _treatmentPlanRepository.UpdateTreatmentPlan(id, treatmentPlan);
        }

        public TreatmentPlan GetDetailedTreatmentPlan(int id)
        {
            return TreatmentPlans
                .Include(c1 => c1.PracticeRoom)
                .Include(c1 => c1.TreatmentPerformedBy)
                    .ThenInclude(a => a.ApplicationUser)
                .FirstOrDefault(i => i.Id == id); 
        }
    }
}
