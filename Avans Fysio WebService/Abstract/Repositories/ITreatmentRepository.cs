using System.Collections.Generic;
using System.Linq;

namespace Avans_Fysio_WebService.Models
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> Treatments { get; }
        IEnumerable<Treatment> FindAll();
        Treatment GetTreatment(string id);
    }
}