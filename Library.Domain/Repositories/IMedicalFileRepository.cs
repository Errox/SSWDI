using Library.core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
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
