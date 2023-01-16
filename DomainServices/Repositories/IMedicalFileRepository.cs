using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface IMedicalFileRepository : IGenericRepository<MedicalFile>
    {
        IQueryable<MedicalFile> MedicalFiles { get; }
        MedicalFile GetMedicalFile(int id);
        void UpdateMedicalFile(int id, MedicalFile medicalFile);
        void AddMedicalFile(MedicalFile medicalFile);
    }
}
