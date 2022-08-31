using Fysio_Codes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fysio_Codes.Abstract
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> Treatments { get; }
        IEnumerable<Treatment> FindAll();
        Treatment GetTreatment(string id);
    }
}