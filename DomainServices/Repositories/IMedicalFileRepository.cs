using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
{
    public interface IMedicalFileRepository
    {
        IQueryable<MedicalFile> MedicalFiles { get; }
        IEnumerable<MedicalFile> FindAll();
        MedicalFile GetMedicalFile(int id);
        void UpdateMedicalFile(int id, MedicalFile medicalFile);
        void AddMedicalFile(MedicalFile medicalFile);
        MedicalFile GetMedicalFileByEmail(string email);
    }
}
