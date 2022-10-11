﻿using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class TreatmentPlanController : Controller
    {
        private ITreatmentPlanRepository _treatmentPlanRepo;
        private IEmployeeRepository _employeeRepo;

        public TreatmentPlanController(ITreatmentPlanRepository treatmentPlanRepo, IEmployeeRepository employee)
        {
            _treatmentPlanRepo = treatmentPlanRepo;
            _employeeRepo = employee;
        }
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: TreatmentController
        public ActionResult Index()
        {
            return View(_treatmentPlanRepo.FindAll());
        }

        [Authorize]
        // GET: TreatmentController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            TreatmentPlan treatmentPlan = _treatmentPlanRepo.TreatmentPlans
                .Include(c1 => c1.PracticeRoom)
                .Include(c1 => c1.TreatmentPerformedBy)
                    .ThenInclude(a => a.ApplicationUser)
                .FirstOrDefault(i => i.Id == id);

            var client = new RestClient($"https://avansfysioservice.azurewebsites.net/api/Treatment/" + treatmentPlan.Type);
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = await client.ExecuteAsync(request);
            //Treatment treatment = JsonConvert.DeserializeObject<Treatment>(response.Content);

            //Fetch all the employee's working on this file

            //ViewBag.Description = treatment.Description;
            
            return View(treatmentPlan);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: TreatmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentController/Create
        [HttpPost]
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentPlan collection)
        {
            try
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Employee employee = _employeeRepo.Employees.FirstOrDefault(i => i.Id.ToString() == userId);

                collection.TreatmentPerformedBy = employee;

                _treatmentPlanRepo.AddTreatmentPlan(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentController/Edit/5
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult Edit(int id)
        {
            return View(_treatmentPlanRepo.GetTreatmentPlan(id));
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TreatmentPlan collection)
        {
            try
            {
                _treatmentPlanRepo.UpdateTreatmentPlan(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
