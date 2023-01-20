using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface ITreatmentPlanService : ITreatmentPlanRepository
    {
        TreatmentPlan GetDetailedTreatmentPlan(int id);
    }
}
