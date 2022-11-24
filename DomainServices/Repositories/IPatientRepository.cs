using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        IQueryable<Patient> Patients { get; }
        Patient GetPatient(int id);
        void UpdatePatient(int id, Patient patient);
        void AddPatient(Patient patient);
    }
}
