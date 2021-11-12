using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Library.DAL;
using Library.Domain.Repositories;

namespace Library.Data
{
    public class EFPatientRepository : IPatientRepository
    {
        private readonly PatientPortalDbContext _context; // TODO: FIX

        public EFPatientRepository(PatientPortalDbContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<Patient> Patients => _context.Users;
        public IEnumerable<Patient> FindAll()
        {
            return _context.Users;
        }

        public Patient GetPatient(int id)
        {
            return _context.Users.FirstOrDefault(i => i.IdNumber == id);
        }

        public void UpdatePatient(int id, Patient patient)
        {
            Patient pre_patient = _context.Users.FirstOrDefault(i => i.IdNumber == id);
            pre_patient.FirstName = patient.FirstName;
            pre_patient.SurName = patient.SurName;
            pre_patient.PhoneNumber = patient.PhoneNumber;
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
