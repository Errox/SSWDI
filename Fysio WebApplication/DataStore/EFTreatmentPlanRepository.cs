﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace Fysio_WebApplication.DataStore
{
    public class EFTreatmentPlanRepository : ITreatmentPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public EFTreatmentPlanRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<TreatmentPlan> TreatmentPlans => _context.TreatmentPlans;

        public void AddTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            _context.Add(treatmentPlan);
            _context.SaveChanges();
        }

        public IEnumerable<TreatmentPlan> FindAll()
        {
            return _context.TreatmentPlans;
        }

        public TreatmentPlan GetTreatmentPlan(int id)
        {
            return _context.TreatmentPlans.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateTreatmentPlan(int id, TreatmentPlan treatmentPlan)
        {
            TreatmentPlan _treatmentplan = _context.TreatmentPlans.Include(c1 => c1.PracticeRoom).FirstOrDefault(i => i.Id == id);
            _treatmentplan.Type = treatmentPlan.Type;
            _treatmentplan.Description = treatmentPlan.Description;
            _treatmentplan.Particularities = treatmentPlan.Particularities;
            _treatmentplan.TreatmentDate = treatmentPlan.TreatmentDate;
            _treatmentplan.AmountOfTreatmentsPerWeek = treatmentPlan.AmountOfTreatmentsPerWeek;
            _treatmentplan.PracticeRoom = treatmentPlan.PracticeRoom;
            _context.SaveChanges();
        }
    }
}
