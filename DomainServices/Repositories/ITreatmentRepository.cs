using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> Treatments { get; }
        IEnumerable<Treatment> FindAll();
        Treatment GetTreatment(string id);
    }
}