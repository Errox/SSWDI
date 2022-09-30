using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private INotesRepository _repo;

        public NoteController(INotesRepository repo)
        {
            _repo = repo;
        }

        // GET: NoteController
        public ActionResult Index()
        {
            return View(_repo.FindAll());
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: NoteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // ONLY WHEN MEDICAL FILE ID IS THERE TO LINK AT
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetNote(id));
        }

        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Note note)
        {
            try
            {
                _repo.UpdateNote(id, note);
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
