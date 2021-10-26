using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Abstract.Repositories
{
    public interface ITreatmentPlanRepository
    {
        IQueryable<TreatmentPlan> TreatmentPlans { get; }
        IEnumerable<TreatmentPlan> FindAll();
        TreatmentPlan GetTreatmentPlan(int id);
        void UpdateTreatmentPlan(TreatmentPlan treatmentPlan);
        void AddTreatmentPlan(TreatmentPlan treatmentPlan);
    }
}
