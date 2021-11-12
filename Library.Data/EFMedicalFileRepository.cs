using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Library.DAL;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class EFMedicalFileRepository : IMedicalFileRepository
    {
        private readonly ApplicationDbContext _context;

        public EFMedicalFileRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<MedicalFile> MedicalFiles => _context.MedicalFiles;

        public IEnumerable<MedicalFile> FindAll()
        {
            return _context.MedicalFiles.Include(i => i.Notes).Include(i => i.TreatmentPlans);
        }

        public MedicalFile GetMedicalFile(int id)
        {
            return _context.MedicalFiles.Include(i=>i.Notes).Include(i=>i.TreatmentPlans).FirstOrDefault(i => i.Id == id);
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
