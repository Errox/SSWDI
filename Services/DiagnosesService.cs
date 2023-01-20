using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DiagnosesService : IDiagnosesService
    {
        private readonly IDiagnosesRepository _diagnosisRepository;
        public DiagnosesService(IDiagnosesRepository diagnosesRepository)
        {
            _diagnosisRepository = diagnosesRepository;
        }

        public IQueryable<Diagnosis> Diagnoses => _diagnosisRepository.Diagnoses;

        public IEnumerable<Diagnosis> FindAll()
        {
            return _diagnosisRepository.FindAll();
        }

        public Diagnosis GetDiagnosis(int id)
        {
            return _diagnosisRepository.GetDiagnosis(id);
        }
    }
}
