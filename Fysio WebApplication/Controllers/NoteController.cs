using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private INotesService _service;

        public NoteController(INotesService service)
        {
            _service = service;
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: NoteController
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // POST: NoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // ONLY WHEN MEDICAL FILE ID IS THERE TO LINK AT ? TODO
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.GetNote(id));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Note note)
        {
            try
            {
                _service.UpdateNote(id, note);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: NoteController/Patient/{Patient.Id}
        //[Route("Note/Patient/{patientId}")]
        //public ActionResult GetPatientNotes(int patientId)
        //{
        //    return View("PatientNotes");
        //}
    }
}
