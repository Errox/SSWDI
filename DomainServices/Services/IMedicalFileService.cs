using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface IMedicalFileService : IMedicalFileRepository
    {
        MedicalFile GetMedicalFileByEmail(string email);
        IQueryable<MedicalFile> GetMedicalFilesWithIntakeUsers();
        IQueryable<MedicalFile> GetMedicalFilesForIntakeSupervision(Employee Employee);
        IQueryable<MedicalFile> GetMedicalFilesForTherapist(Employee Employee);
        MedicalFile GetDetailedMedicalFileById(int id);
    }
}
