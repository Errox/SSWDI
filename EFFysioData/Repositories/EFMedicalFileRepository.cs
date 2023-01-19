using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.Repositories
{
    public class EFMedicalFileRepository : EFGenericRepository<MedicalFile>, IMedicalFileRepository
    {
        private readonly ApplicationDbContext _context;

        public EFMedicalFileRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public IQueryable<MedicalFile> MedicalFiles => _context.MedicalFiles;

        public IEnumerable<MedicalFile> FindAll()
        {
            return _context.MedicalFiles;
        }

        public MedicalFile GetMedicalFile(int id)
        {
            return _context.MedicalFiles.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateMedicalFile(int id, MedicalFile medicalFile)
        {
            MedicalFile file = _context.MedicalFiles.Include(i => i.Notes).Include(i => i.TreatmentPlans).FirstOrDefault(i => i.Id == id);
            file.Description = medicalFile.Description;
            file.DiagnosisCode = medicalFile.DiagnosisCode;
            file.DateOfDischarge = medicalFile.DateOfDischarge;
            _context.SaveChanges();
        }

        public void AddMedicalFile(MedicalFile medicalFile)
        {
            medicalFile.DateOfCreation = DateTime.Now;
            _context.Add(medicalFile);
            _context.SaveChanges();
        }

    }
}
