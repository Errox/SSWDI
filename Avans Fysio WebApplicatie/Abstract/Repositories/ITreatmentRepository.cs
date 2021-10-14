using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
{
    public interface ITreatmentRepository
    {
        IQueryable<TreatmentPlan> TreatmentPlans { get; }
        IEnumerable<TreatmentPlan> FindAll();
        TreatmentPlan GetTreatmentPlan(int id);
        void UpdateTreatmentPlan(TreatmentPlan treatmentPlan);
        void AddTreatmentPlan(TreatmentPlan treatmentPlan);
    }
}
