using Library.core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public interface IPatientRepository
    {
        IQueryable<Patient> Patients { get; }
        IEnumerable<Patient> FindAll();
        Patient GetPatient(int id);
        void UpdatePatient(int id, Patient patient);
        void AddPatient(Patient patient);
    }
}
