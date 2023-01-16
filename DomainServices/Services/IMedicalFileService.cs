using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface IMedicalFileService : IMedicalFileRepository
    {
        MedicalFile GetMedicalFileByEmail(string email);
    }
}
