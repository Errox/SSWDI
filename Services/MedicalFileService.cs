using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MedicalFileService : IMedicalFileService
    {
        private readonly IMedicalFileRepository _medicalFileRepository;
        private readonly ITreatmentPlanRepository _treatmentPlanRepository;
        private readonly IAppointmentsRepository _appointmentsRepository;
        
        public MedicalFileService(IMedicalFileRepository medicalFileRepository, ITreatmentPlanRepository treatmentPlanRepository, IAppointmentsRepository appointmentsRepository)
        {
            _medicalFileRepository = medicalFileRepository;
            _treatmentPlanRepository = treatmentPlanRepository;
            _appointmentsRepository = appointmentsRepository;
        }


        public IQueryable<MedicalFile> MedicalFiles => _medicalFileRepository.MedicalFiles.Include(i => i.Notes).Include(i => i.TreatmentPlans).ThenInclude(x => x.PracticeRoom);

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

        public IQueryable<MedicalFile> GetMedicalFilesWithIntakeUsers()
        {
            return MedicalFiles
                .Include(i => i.IntakeSupervision)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.IntakeTherapistId)
                    .ThenInclude(i => i.ApplicationUser);
        }
        
        public IQueryable<MedicalFile> GetMedicalFilesForIntakeSupervision(Employee Employee)
        {
            return MedicalFiles
                .Include(i => i.IntakeSupervision)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.IntakeTherapistId)
                    .ThenInclude(i => i.ApplicationUser)
                .Where(i => i.IntakeSupervision == Employee);
        }

        public IQueryable<MedicalFile> GetMedicalFilesForTherapist(Employee Employee)
        {
            return MedicalFiles
                .Include(i => i.IntakeSupervision)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.IntakeTherapistId)
                    .ThenInclude(i => i.ApplicationUser)
                .Where(i => i.IntakeTherapistId == Employee);
        }

        public MedicalFile GetDetailedMedicalFileById(int id)
        {
            return MedicalFiles
            .Include(i => i.IntakeSupervision)
                .ThenInclude(e => e.ApplicationUser)
            .Include(i => i.IntakeTherapistId)
                .ThenInclude(c => c.ApplicationUser)
            .FirstOrDefault(i => i.Id == id);
        }

        public void AddTreatmentPlanToMedicalFile(int medicalFileId, TreatmentPlan treatmentplan)
        {
            MedicalFile file = _medicalFileRepository.GetMedicalFile(medicalFileId);

            if (file.PatientEmail == null)
            {
                throw new InvalidOperationException("A treatment can only be set when the patient is registered in the system");
            }
            
            file.TreatmentPlans.Add(treatmentplan);

            _medicalFileRepository.UpdateMedicalFile(medicalFileId, file);
        }


    }
}
