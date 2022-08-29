using System.Collections.Generic;
using System.Linq;
using MainLibrary.DomainModel;

namespace Avans_Fysio_WebService.Models
{
    public interface IDiagnosesRepository
    {
        IQueryable<Diagnosis> Diagnoses { get; }

        IEnumerable<Diagnosis> FindAll();

        Diagnosis GetDiagnosis(int id);

    }
}
