using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
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
