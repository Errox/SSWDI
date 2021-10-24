using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.DAL;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;

namespace Fysio_WebApplication.DataStore
{
    public class EFPatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

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
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }
    }
}
