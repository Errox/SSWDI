using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;

namespace Library.Data.Repositories
{
    public class EFPatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context; // TODO: FIX

        public EFPatientRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Patient> Patients => _context.Patients;

        public IEnumerable<Patient> FindAll()
        {
            return _context.Patients;
        }

        public Patient GetPatient(int id)
        {
            return _context.Patients.FirstOrDefault(i => i.IdNumber == id);
        }

        public void UpdatePatient(int id, Patient patient)
        {
            Patient pre_patient = _context.Patients.FirstOrDefault(i => i.IdNumber == id);

            //TODO: Pretty sure that the below code is not needed; but left it just in case -W

            pre_patient.FirstName = patient.FirstName;
            pre_patient.SurName = patient.SurName;
            // pre_patient.PhoneNumber = patient.PhoneNumber;
            pre_patient.Email = patient.Email;
            pre_patient.Gender = patient.Gender;
            pre_patient.IsStudent = patient.IsStudent;
            pre_patient.ImgData = patient.ImgData;
            pre_patient.MedicalFile = patient.MedicalFile;
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }
    }
}
