using Fysio_Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_Codes.Abstract
{
    public interface IDiagnosesRepository
    {
        IQueryable<Diagnosis> Diagnoses { get; }

        IEnumerable<Diagnosis> FindAll();

        Diagnosis GetDiagnosis(int id);

    }
}
