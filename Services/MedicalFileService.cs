using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MedicalFileService : IMedicalFileService
    {
        private readonly IMedicalFileRepository _medicalFileRepository;

        public MedicalFileService(IMedicalFileRepository medicalFileRepository)
        {
            _medicalFileRepository = medicalFileRepository;
        }


        public IQueryable<MedicalFile> MedicalFiles => _medicalFileRepository.MedicalFiles.Include(i => i.Notes).Include(i => i.TreatmentPlans);

        public void Add(MedicalFile entity)
        {
            _medicalFileRepository.Add(entity);
        }

        public void AddMedicalFile(MedicalFile medicalFile)
        {
            _medicalFileRepository.AddMedicalFile(medicalFile);
        }

        public MedicalFile FindByID(int ID)
        {
            return _medicalFileRepository.FindByID(ID);
        }

        public IEnumerable<MedicalFile> GetAll()
        {
            return MedicalFiles;
        }

        public MedicalFile GetMedicalFile(int id)
        {
            return MedicalFiles.FirstOrDefault(i => i.Id == id);
        }

        public MedicalFile GetMedicalFileByEmail(string email)
        {
            return MedicalFiles.FirstOrDefault(i => i.PatientEmail == email);   
        }

        public void Remove(MedicalFile entity)
        {
            _medicalFileRepository.Remove(entity);
        }

        public void Update(int id, MedicalFile medicalFile)
        {
            _medicalFileRepository.UpdateMedicalFile(id, medicalFile);
        }

        public void UpdateMedicalFile(int id, MedicalFile medicalFile)
        {
            _medicalFileRepository.UpdateMedicalFile(id, medicalFile);
        }
    }
}
