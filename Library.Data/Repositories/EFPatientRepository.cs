using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Repositories
{
    public class EFPatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public EFPatientRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Patient> Patients => _context.Patients.Include(c1 => c1.ApplicationUser);

        public IEnumerable<Patient> FindAll()
        {
            return _context.Patients.Include(c1 => c1.ApplicationUser);
        }

        public Patient GetPatient(int id)
        {
            return _context.Patients.Include(c1 => c1.ApplicationUser).FirstOrDefault(i => i.IdNumber == id);
        }

        public void UpdatePatient(int id, Patient patient)
        {
            Patient oldPatient = _context.Patients.Include(c1 => c1.ApplicationUser).FirstOrDefault(i => i.IdNumber == id);
            oldPatient.ImgData = patient.ImgData;
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }
    }
}
