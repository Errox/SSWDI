using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.Repositories
{
    public class EFPatientRepository : EFGenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public EFPatientRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public IQueryable<Patient> Patients => _context.Patients;

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
            oldPatient.DateOfBirth = patient.DateOfBirth;
            oldPatient.Gender = patient.Gender;
            oldPatient.IsStudent = patient.IsStudent;
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }
    }
}
