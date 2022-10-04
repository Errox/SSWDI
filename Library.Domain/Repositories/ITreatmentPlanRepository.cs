using Library.core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public interface ITreatmentPlanRepository
    {
        IQueryable<TreatmentPlan> TreatmentPlans { get; }
        IEnumerable<TreatmentPlan> FindAll();
        TreatmentPlan GetTreatmentPlan(int id);
        void UpdateTreatmentPlan(int id, TreatmentPlan treatmentPlan);
        void AddTreatmentPlan(TreatmentPlan treatmentPlan);
    }
}
