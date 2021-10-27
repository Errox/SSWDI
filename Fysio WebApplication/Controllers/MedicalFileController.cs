using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.DataStore;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    public class MedicalFileController : Controller
    {
        private IMedicalFileRepository _repo;
        private IEmployeeRepository _employeeRepo;

        public MedicalFileController(IMedicalFileRepository repo, IEmployeeRepository employeeRepo)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
        }

        // GET: MedicalFile
        public ActionResult Index()
        {

            return View(_repo.FindAll());
        }

        // GET: MedicalFile/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetMedicalFile(id));
        }

        // GET: MedicalFile/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetMedicalFile(id));
        }

        // POST: MedicalFile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicalFile collection)
        {
            try
            {
                _repo.UpdateMedicalFile(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [Route("[Controller]/Notes/{id}")]
        public ActionResult Notes(int id)
        {
            // Return all notes for this medical thing
            ICollection<Note> notes = _repo.GetMedicalFile(id).Notes;
            return View(_repo.GetMedicalFile(id).Notes);
        }
    }
}
