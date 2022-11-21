using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
{
    public interface IDiagnosesRepository
    {
        IQueryable<Diagnosis> Diagnoses { get; }

        IEnumerable<Diagnosis> FindAll();

        Diagnosis GetDiagnosis(int id);

    }
}
