using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Areas.Identity.Data;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    public class TreatmentPlanController : Controller
    {
        private ITreatmentPlanRepository _repo;
        private UserManager<Employee> _usermanager;

        public TreatmentPlanController(ITreatmentPlanRepository repo, UserManager<Employee> UserManager)
        {
            _repo = repo;
            _usermanager = UserManager;
        }

        // GET: TreatmentController
        public ActionResult Index()
        {
            return View(_repo.FindAll());
        }

        // GET: TreatmentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetTreatmentPlan(id));
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
                collection.TreatmentPerformedBy = userId;
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
