using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> Treatments { get; }
        IEnumerable<Treatment> FindAll();
        Treatment GetTreatment(string id);
    }
}