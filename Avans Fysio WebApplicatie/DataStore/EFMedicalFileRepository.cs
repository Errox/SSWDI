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
    public class EFMedicalFileRepository : IMedicalFile
    {
        private readonly WebApplicationDbContext _context;

        public EFMedicalFileRepository(WebApplicationDbContext ctx)
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

        public void UpdateMedicalFile(Patient patient)
        {
            _context.SaveChanges();
        }

        public void AddMedicalFile(MedicalFile medicalFile)
        {
            _context.Add(medicalFile);
            _context.SaveChanges();
        }
    }
}
