using MainLibrary.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.DomainServies
{
    public interface IDiagnosesRepository
    {
        IQueryable<Diagnosis> Diagnoses { get; }

        //IQueryable<Treatment> Treatments { get; }
    }
}
