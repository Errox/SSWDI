using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;

namespace Fysio_WebApplication.DataStore
{
    public class EFMedicalFileRepository : IMedicalFile
    {
        private readonly ApplicationDbContext _context;

        public EFMedicalFileRepository(ApplicationDbContext ctx)
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
