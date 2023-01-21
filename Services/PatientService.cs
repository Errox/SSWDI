using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IQueryable<Patient> Patients => _patientRepository.Patients.Include(c1 => c1.ApplicationUser);

        public void Add(Patient entity)
        {
            _patientRepository.Add(entity);
        }

        public void AddPatient(Patient patient)
        {
            
            _patientRepository.AddPatient(patient);
        }

        public Patient FindByID(int ID)
        {
            return _patientRepository.FindByID(ID);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatient(int id)
        {
            return _patientRepository.GetPatient(id);
        }

        public void Remove(Patient entity)
        {
            _patientRepository.Remove(entity);
        }

        public void Update(int id, Patient entity)
        {
            _patientRepository.Update(id, entity);
        }

        public void UpdatePatient(int id, Patient patient)
        {
            _patientRepository.UpdatePatient(id, patient);
        }

        public Patient GetPatientWithMedicalFile(string patientId)
        {
            return _patientRepository.Patients
                .Include(x => x.MedicalFile)
                    .ThenInclude(x => x.IntakeTherapistId)
                        .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.MedicalFile)
                    .ThenInclude(x => x.TreatmentPlans)
                .FirstOrDefault(x => x.PatientId == patientId);
        }

        public Patient GetPatientByMedicalFile(int id)
        {
            return Patients
                .Include(x => x.MedicalFile)
                .ThenInclude(x => x.TreatmentPlans)
                .FirstOrDefault(x => x.MedicalFile.Id == id);
        }

    }
}
