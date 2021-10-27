using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Abstract.Repositories
{
    public interface IMedicalFileRepository
    {
        IQueryable<MedicalFile> MedicalFiles { get; }
        IEnumerable<MedicalFile> FindAll();
        MedicalFile GetMedicalFile(int id);
        void UpdateMedicalFile(int id, MedicalFile medicalFile);
        void AddMedicalFile(MedicalFile medicalFile);
    }
}
