using Avans_Fysio_WebService.Models;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Areas.Identity.Data;
using Fysio_WebApplication.DataStore;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class MedicalFileController : Controller
    {
        private IMedicalFileRepository _repo;
        private IEmployeeRepository _employeeRepo;
        private ITreatmentPlanRepository _treatmentPlanRepository;
        private INotesRepository _notesRepository;
        private IPracticeRoomRepository _practiceRoomRepository;

        public MedicalFileController(IMedicalFileRepository repo, IEmployeeRepository employeeRepo, ITreatmentPlanRepository treatmentPlanRepository, INotesRepository notesRepository, IPracticeRoomRepository practiceRoomRepository)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
            _treatmentPlanRepository = treatmentPlanRepository;
            _notesRepository = notesRepository;
            _practiceRoomRepository = practiceRoomRepository;
        }

        // GET: MedicalFile
        public ActionResult Index()
        {
            return View(_repo.FindAll());
        }

        public ActionResult IndexPersonalSupervise()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_repo.MedicalFiles.Where(i => i.IntakeSupervision == userId));
        }

        public ActionResult IndexPersonalTherapist()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_repo.MedicalFiles.Where(i => i.IntakeTherapistId == userId));
        }

        // GET: MedicalFile/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            // Get the detailed medical File
            MedicalFile medical = _repo.GetMedicalFile(id);

            //Fetch the diagnosis containing the code
            var client = new RestClient($"https://avansfysioservice.azurewebsites.net/api/Diagnosis/"+medical.DiagnosisCode);
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            Diagnosis diagnosis = JsonConvert.DeserializeObject<Diagnosis>(response.Content);


            //Fetch all the employee's working on this file.
            Employee supervision = _employeeRepo.GetEmployee(medical.IntakeSupervision);
            Employee therapist = _employeeRepo.GetEmployee(medical.IntakeTherapistId);


            //Send them towards the view
            ViewBag.BodyLocation = diagnosis.BodyLocation;
            ViewBag.Pathology = diagnosis.Pathology;
            ViewBag.Supervision = supervision.FirstName + " " + supervision.SurName;
            ViewBag.Therapist = therapist.FirstName + " " + therapist.SurName;
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
            MedicalFile file = _repo.MedicalFiles.Include(c1 => c1.Notes).FirstOrDefault(i => i.Id == id);
            return View(file.Notes);
        }

        [HttpGet]
        [Route("[Controller]/NotesNew/{id}")]
        public ActionResult NotesNew(int id)
        {
            ViewBag.Url = "/MedicalFile/NotesNew/" + id;
            return View();
        }

        [HttpPost]
        [Route("[Controller]/NotesNew/{id}")]
        public ActionResult NotesnNew(int id, Note newNote)
        {
            // Get the current logged in.
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //Create new plan because somehow it'll take the medicalFile ID and places it in the model instead of keeping it empty to insert in the DB
            Note note = new Note { IdEmployee = userId, Description = newNote.Description, CreatedUtc = DateTime.Now, OpenForPatient = newNote.OpenForPatient };
            
            _notesRepository.AddNote(note);

            //Add the Treatmentplan to the medicalFile
            MedicalFile medicalFile = _repo.MedicalFiles.Include(i => i.Notes).FirstOrDefault(i => i.Id == id);
            medicalFile.Notes.Add(note);
            _repo.UpdateMedicalFile(id, medicalFile);

            //Return view
            return Redirect("/MedicalFile/Notes/" + id);
        }

        [Route("[Controller]/TreatmentPlan/{id}")]
        public ActionResult TreatmentPlan(int id)
        {
            // Return all TreatmentPlan for this medical File
            MedicalFile file = _repo.MedicalFiles.Include(c1 => c1.TreatmentPlans).ThenInclude(i=>i.PracticeRoom).FirstOrDefault(i => i.Id == id);
            ViewBag.Url = "/MedicalFile/" + file.Id + "/AddRoomTreatment/";
            return View(file.TreatmentPlans);
        }

        [HttpGet]
        [Route("[Controller]/TreatmentPlanNew/{id}")]
        public ActionResult TreatmentPlanNew(int id)
        {
            ViewBag.Url = "/MedicalFile/TreatmentPlanNew/"+id;
            return View();
        }

        [HttpPost]
        [Route("[Controller]/TreatmentPlanNew/{id}")]
        public ActionResult TreatmentPlanNew(int id, TreatmentPlan plan)
        {
            // Get the current logged in.
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //Create new plan because somehow it'll take the medicalFile ID and places it in the model instead of keeping it empty to insert in the DB
            TreatmentPlan NewPlan = new TreatmentPlan { Type = plan.Type, Description = plan.Description, Particularities = plan.Particularities, TreatmentPerformedBy = userId, TreatmentDate = plan.TreatmentDate, AmountOfTreatmentsPerWeek = plan.AmountOfTreatmentsPerWeek };
            _treatmentPlanRepository.AddTreatmentPlan(NewPlan);

            //Add the Treatmentplan to the medicalFile
            MedicalFile medicalFile = _repo.MedicalFiles.Include(i => i.TreatmentPlans).FirstOrDefault(i => i.Id == id);
            medicalFile.TreatmentPlans.Add(NewPlan);
            _repo.UpdateMedicalFile(id, medicalFile);

            //Return view
            return Redirect("/MedicalFile/TreatmentPlan/" + id);
        }

        [HttpGet]
        [Route("[Controller]/{file}/AddRoomTreatment/{id}")]
        public ActionResult AddRoomTreatment(int file, int id)
        {
            ViewBag.Url = "/MedicalFile/"+ file +"/AddRoomTreatment/" + id;
            ViewBag.Rooms = new SelectList(_practiceRoomRepository.FindAll(), "Id", "Name"); ;
            return View();
        }

        [HttpPost]
        [Route("[Controller]/{file}/AddRoomTreatment/{treatment}")]
        public ActionResult AddRoomTreatment(int file, int treatment, PracticeRoom Room)
        {
            //Add the Room to the 
            TreatmentPlan treatmentPlan = _treatmentPlanRepository.TreatmentPlans.FirstOrDefault(i => i.Id == treatment);
            PracticeRoom room = _practiceRoomRepository.GetPracticeRoom(Room.Id);
            treatmentPlan.PracticeRoom = room;

            _treatmentPlanRepository.UpdateTreatmentPlan(treatmentPlan.Id, treatmentPlan);

            //Return view
            return Redirect("/MedicalFile/TreatmentPlan/" + file);
        }


    }
}
