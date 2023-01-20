using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface IPatientService : IPatientRepository
    {
        public Patient GetPatientWithMedicalFile(string patientId);
        Patient GetPatientByMedicalFile(int id);
    }
}
