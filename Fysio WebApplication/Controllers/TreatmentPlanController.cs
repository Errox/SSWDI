using Fysio_Codes.Models;
using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class TreatmentPlanController : Controller
    {
        private ITreatmentPlanRepository _repo;
        private IEmployeeRepository _employeeRepo;

        public TreatmentPlanController(ITreatmentPlanRepository repo,  IEmployeeRepository employee)
        {
            _repo = repo;
            _employeeRepo = employee;
        }

        // GET: TreatmentController
        public ActionResult Index()
        {
            return View(_repo.FindAll());
        }

        // GET: TreatmentController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            TreatmentPlan treatmentPlan = _repo.TreatmentPlans.Include(c1 => c1.PracticeRoom).Include(c1=>c1.TreatmentPerformedBy).FirstOrDefault(i => i.Id == id);

            var client = new RestClient($"https://avansfysioservice.azurewebsites.net/api/Treatment/" + treatmentPlan.Type);
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = await client.ExecuteAsync(request);
            //Treatment treatment = JsonConvert.DeserializeObject<Treatment>(response.Content);

            //Fetch all the employee's working on this file

            //ViewBag.Description = treatment.Description;
            ViewBag.Performed = treatmentPlan.TreatmentPerformedBy.FirstName + " " + treatmentPlan.TreatmentPerformedBy.SurName;

            return View(treatmentPlan);
        }

        // GET: TreatmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentPlan collection)
        {
            try
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Employee employee = _employeeRepo.Employees.FirstOrDefault(i => i.ID.ToString() == userId);

                collection.TreatmentPerformedBy = employee;

                _repo.AddTreatmentPlan(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetTreatmentPlan(id));
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TreatmentPlan collection)
        {
            try
            {
                _repo.UpdateTreatmentPlan(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
