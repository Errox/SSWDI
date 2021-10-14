using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Abstract.Repositories;
using Avans_Fysio_WebApplicatie.Data;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.DataStore
{
    public class EFPatientRepository : IPatientRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFPatientRepository(WebApplicationDbContext ctx)
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
            return _context.Patients.FirstOrDefault(i => i.PatientId == id);
        }

        public void UpdatePatient(int id, Patient patient)
        {
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }
    }
}
