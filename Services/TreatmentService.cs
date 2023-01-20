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
    public class TreatmentService : ITreatmentServices
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }
        public IQueryable<Treatment> Treatments => _treatmentRepository.Treatments;

        public IEnumerable<Treatment> FindAll()
        {
            return _treatmentRepository.FindAll();
        }

        public Treatment GetTreatment(string id)
        {
            return _treatmentRepository.GetTreatment(id);
        }
    }
}
