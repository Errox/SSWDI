using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface ITreatmentPlanRepository : IGenericRepository<TreatmentPlan>
    {
        IQueryable<TreatmentPlan> TreatmentPlans { get; }
        TreatmentPlan GetTreatmentPlan(int id);
        void UpdateTreatmentPlan(int id, TreatmentPlan treatmentPlan);
        void AddTreatmentPlan(TreatmentPlan treatmentPlan);
    }
}
