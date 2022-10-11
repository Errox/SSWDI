using Fysio_Codes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fysio_Codes.Abstract
{
    public interface IDiagnosesRepository
    {
        IQueryable<Diagnosis> Diagnoses { get; }

        IEnumerable<Diagnosis> FindAll();

        Diagnosis GetDiagnosis(int id);

    }
}
