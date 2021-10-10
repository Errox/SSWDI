using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.Models
{
    public interface IDiagnosesRepository
    {
        IQueryable<Diagnosis> Diagnoses { get; }

        IEnumerable<Diagnosis> FindAll();

        Diagnosis GetDiagnosis(int id);

    }
}
