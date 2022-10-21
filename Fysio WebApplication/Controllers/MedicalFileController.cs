using Library.core.Model;
using Library.Data.Repositories;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class MedicalFileController : Controller
    {
        private IMedicalFileRepository _repo;
        private IEmployeeRepository _employeeRepo;
        private IPatientRepository _patientRepository;
        private ITreatmentPlanRepository _treatmentPlanRepository;
        private INotesRepository _notesRepository;
        private IAppointmentsRepository _appointmentsRepository;
        private IAvailabilityRepository _availabilityRepository;
        private IPracticeRoomRepository _practiceRoomRepository;

        public MedicalFileController(
            IMedicalFileRepository repo,
            IEmployeeRepository employeeRepo,
            IPatientRepository patientRepository,
            ITreatmentPlanRepository treatmentPlanRepository,
            INotesRepository notesRepository,
            IAppointmentsRepository appointmentsRepository,
            IAvailabilityRepository availabilityRepository,
            IPracticeRoomRepository practiceRoomRepository)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
            _patientRepository = patientRepository;
            _treatmentPlanRepository = treatmentPlanRepository;
            _notesRepository = notesRepository;
            _appointmentsRepository = appointmentsRepository;
            _availabilityRepository = availabilityRepository;
            _practiceRoomRepository = practiceRoomRepository;
        }

        [Authorize]
        // GET: MedicalFile
        public ActionResult Index()
        {
            var files = _repo.MedicalFiles
                .Include(i => i.IntakeSupervision)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.IntakeTherapistId)
                    .ThenInclude(i => i.ApplicationUser);
            if (User.HasClaim("UserType", "Patient"))
            {
                Patient patient = _patientRepository.Patients.Include(m => m.MedicalFile).FirstOrDefault(x => x.PatientId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Redirect("/MedicalFile/Details/" + patient.MedicalFile.Id);
            }
            return View(files);
        }
        
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult IndexPersonalSupervise()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_repo.MedicalFiles
                .Include(i => i.IntakeSupervision)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.IntakeTherapistId)
                    .ThenInclude(i => i.ApplicationUser)
                .Where(i => i.IntakeSupervision == _employeeRepo.GetEmployee(userId)));
        }
        
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult IndexPersonalTherapist()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_repo.MedicalFiles
                .Include(i => i.IntakeSupervision)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.IntakeTherapistId)
                    .ThenInclude(i => i.ApplicationUser)
                .Where(i => i.IntakeTherapistId == _employeeRepo.GetEmployee(userId)));
        }

        [Authorize]
        // GET: MedicalFile/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            // Get the detailed medical File
            MedicalFile medical = _repo.MedicalFiles
            .Include(i => i.IntakeSupervision)
                .ThenInclude(e => e.ApplicationUser)
            .Include(i => i.IntakeTherapistId)
                .ThenInclude(c => c.ApplicationUser)
            .FirstOrDefault(i => i.Id == id);


            // TODO: Make this into a graphql. 
            //Fetch the diagnosis containing the code
            //var client = new RestClient($"https://avansfysioservice.azurewebsites.net/api/Diagnosis/"+medical.DiagnosisCode);
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = await client.ExecuteAsync(request);
            //Diagnosis diagnosis = JsonConvert.DeserializeObject<Diagnosis>(response.Content);
            //TODO Fix the pathelogical thing. Diagnose code stuff.
            ////Send them towards the view
            //ViewBag.BodyLocation = "TODO";//diagnosis.BodyLocation;
            //ViewBag.Pathology = "TODO";//diagnosis.Pathology;


            if (User.HasClaim("UserType", "Employee") || User.HasClaim("UserType", "Student")) return View(_repo.GetMedicalFile(id));


            if (User.HasClaim("UserType", "Patient"))
            {
                // Get the patient.
                Patient patient = _patientRepository.Patients.Include(m => m.MedicalFile).FirstOrDefault(x => x.PatientId == User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Check if the patient medicalfile is the same as the user
                if (patient.MedicalFile.Id == id) return View(_repo.GetMedicalFile(id));
            }

            return RedirectToAction("AccessDenied", "Error");
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: MedicalFile/Edit/5
        public ActionResult Edit(int id)
        {
            // TODO: Get the webservice data in it too. Either from graphql or API. 
            return View(_repo.GetMedicalFile(id));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
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

        [Authorize]
        [Route("[Controller]/Notes/{id}")]
        public ActionResult Notes(int id)
        {
            // Check if the medicalfile from the patient has the same value as the userID. 
            if (User.HasClaim("UserType", "Patient"))
            {
                Patient patient = _patientRepository.Patients.Include(m => m.MedicalFile).FirstOrDefault(x => x.PatientId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (patient.MedicalFile.Id != id) return RedirectToAction("AccessDenied", "Error");
            }


            MedicalFile file = _repo.MedicalFiles.Include(c1 => c1.Notes).FirstOrDefault(i => i.Id == id);
            
            if (User.HasClaim("UserType", "Patient") || User.HasClaim("UserType", "Student"))
            {
                return View(file.Notes.Where(x => x.OpenForPatient == true));
            }

            // Return all notes for this medical thing
            return View(file.Notes);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpGet]
        [Route("[Controller]/NotesNew/{id}")]
        public ActionResult NotesNew(int id)
        {
            ViewBag.Url = "/MedicalFile/NotesNew/" + id;
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [Route("[Controller]/NotesNew/{id}")]
        public ActionResult NotesNew(int id, Note newNote)
        {
            //Create new plan because somehow it'll take the medicalFile ID and places it in the model instead of keeping it empty to insert in the DB
            Note note = new Note
            {
                Employee = _employeeRepo.GetEmployee(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                Description = newNote.Description,
                CreatedUtc = DateTime.Now,
                OpenForPatient = newNote.OpenForPatient
            };

            _notesRepository.AddNote(note);

            //Add the Treatmentplan to the medicalFile
            MedicalFile medicalFile = _repo.MedicalFiles
                .Include(i => i.Notes)
                .Include(i => i.IntakeSupervision)
                .Include(i => i.IntakeTherapistId)
                .FirstOrDefault(i => i.Id == id);
            
            medicalFile.Notes.Add(note);
            _repo.UpdateMedicalFile(id, medicalFile);

            //Return view
            return Redirect("/MedicalFile/Notes/" + id);
        }

        [Authorize]
        [Route("[Controller]/TreatmentPlan/{id}")]
        public ActionResult TreatmentPlan(int id)
        {
            Patient patient = _patientRepository.Patients
                .Include(m => m.MedicalFile)
                    .ThenInclude(c2 => c2.TreatmentPlans)
                .FirstOrDefault(x => x.PatientId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            if (patient.MedicalFile.Id != id) return RedirectToAction("AccessDenied", "Error");

            // Return all TreatmentPlan for this medical File
            MedicalFile file = _repo.MedicalFiles.Include(c1 => c1.TreatmentPlans).ThenInclude(i => i.PracticeRoom).FirstOrDefault(i => i.Id == id);


            ViewBag.Url = "/MedicalFile/" + file.Id + "/AddRoomTreatment/";
            return View(file.TreatmentPlans);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpGet]
        [Route("[Controller]/TreatmentPlanNew/{id}")]
        public ActionResult TreatmentPlanNew(int id)
        {
            ViewBag.Url = "/MedicalFile/TreatmentPlanNew/" + id;
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [Route("[Controller]/TreatmentPlanNew/{id}")]
        public ActionResult TreatmentPlanNew(int id, TreatmentPlan plan)
        {
            //Create new plan because somehow it'll take the medicalFile ID and places it in the model instead of keeping it empty to insert in the DB
            Employee employee = _employeeRepo.GetEmployee(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            TreatmentPlan NewPlan = new TreatmentPlan { Type = plan.Type, Description = plan.Description, Particularities = plan.Particularities, TreatmentPerformedBy = employee, TreatmentDate = plan.TreatmentDate, AmountOfTreatmentsPerWeek = plan.AmountOfTreatmentsPerWeek };
            _treatmentPlanRepository.AddTreatmentPlan(NewPlan);

            //Add the Treatmentplan to the medicalFile
            MedicalFile medicalFile = _repo.MedicalFiles.Include(i => i.TreatmentPlans).FirstOrDefault(i => i.Id == id);
            medicalFile.TreatmentPlans.Add(NewPlan);
            _repo.UpdateMedicalFile(id, medicalFile);

            //Return view
            return Redirect("/MedicalFile/TreatmentPlan/" + id);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpGet]
        [Route("[Controller]/{file}/AddRoomTreatment/{id}")]
        public ActionResult AddRoomTreatment(int file, int id)
        {
            ViewBag.Url = "/MedicalFile/" + file + "/AddRoomTreatment/" + id;
            ViewBag.Rooms = new SelectList(_practiceRoomRepository.FindAll(), "Id", "Name"); ;
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
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

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult Appointment(int id)
        {
            // getting the appointment that might be set on this medical file.
            Patient patient = _patientRepository.Patients.Include(x => x.MedicalFile).FirstOrDefault(x => x.MedicalFile.Id == id);

            Appointment appointment = _appointmentsRepository.Appointments
                .Include(x=> x.Employee)
                    .ThenInclude(x=> x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.TimeSlot)
                .FirstOrDefault(x => x.Patient == patient);

            if (appointment is null)
            {
                ViewBag.Error = "No appointment found for this patient. It's possible to create one here";
                return Redirect("/MedicalFile/AppointmentNew/" + id);
            }

            ViewBag.StartTime = appointment.TimeSlot.StartAvailability.ToString("t");
            ViewBag.StopTime = appointment.TimeSlot.StopAvailability.ToString("t");
            ViewBag.Date = appointment.TimeSlot.StartAvailability.ToString("d");

            return View(appointment);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpGet]
        public ActionResult AppointmentNew(int id)
        {
            // A new appointment on this medical file / patient. 
            Patient patient = _patientRepository.Patients.Include(x => x.MedicalFile).FirstOrDefault(x => x.MedicalFile.Id == id);
            // Here we get the patient into making a appointment with the doctor. 

            Patient currentlyLoggedIn = _patientRepository.Patients
                .Include(x => x.MedicalFile)
                    .ThenInclude(x => x.IntakeTherapistId)
                        .ThenInclude(x => x.ApplicationUser)
                .FirstOrDefault(x => x.PatientId == patient.PatientId);

            // Check if the patient already has a appointment.
            if (_appointmentsRepository.Appointments
                .FirstOrDefault(x => x.Patient.PatientId == patient.PatientId) != null)
            {
                // If the patient already has a appointment, we redirect the patient to the details page of the appointment.
                return RedirectToAction("Details", "Appointment");
            }

            IEnumerable<Availability> availability = _availabilityRepository.Availabilities
                .Where(x => x.IsAvailable == true)
                .Where(x => x.Employee == currentlyLoggedIn.MedicalFile.IntakeTherapistId);

            SelectList selectlist = new SelectList(availability, "Id", "StartAvailability");


            ViewBag.Brands = new SelectList(_availabilityRepository.Availabilities
                .Where(x => x.IsAvailable == true)
                .Where(x => x.Employee == currentlyLoggedIn.MedicalFile.IntakeTherapistId).ToList(), "Id", "StartAvailability");

            ViewBag.Patient = currentlyLoggedIn;
            ViewBag.Availability = availability;
            ViewBag.SelectList = selectlist;
            ViewBag.PostUrl = "/MedicalFile/AppointmentNew/" + id;


            return View();
        }
        
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [Route("[Controller]/AppointmentNew/{medicalfileId}")]
        public ActionResult AppointmentNew(int medicalfileId, IFormCollection foFormCollection)
        {
            // A new appointment on this medical file / patient. 
            Patient patient = _patientRepository.Patients.Include(x => x.MedicalFile).FirstOrDefault(x => x.MedicalFile.Id == medicalfileId);

            var Id = Convert.ToInt32(foFormCollection["id"]);
            var availability = _availabilityRepository.Availabilities
                .Include(x => x.Employee)
                    .ThenInclude(x => x.ApplicationUser)
                .FirstOrDefault(x => x.Id == Id);
            
            Patient currentlyLoggedIn = _patientRepository.Patients
                .Include(x => x.MedicalFile)
                    .ThenInclude(x => x.IntakeTherapistId)
                        .ThenInclude(x => x.ApplicationUser)
                .FirstOrDefault(x => x.PatientId == patient.PatientId);

            Appointment appointment = new Appointment();

            appointment.TimeSlot = availability;
            appointment.Patient = currentlyLoggedIn;
            appointment.Employee = currentlyLoggedIn.MedicalFile.IntakeTherapistId;


            availability.Patient = currentlyLoggedIn;

            _availabilityRepository.UpdateAvailability(availability);
            _appointmentsRepository.AddAppointment(appointment);
            
            Appointment appointmentNew = new Appointment
            {
                Patient = patient,
                Employee = _employeeRepo.GetEmployee(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                TimeSlot = availability,
            };

            _appointmentsRepository.AddAppointment(appointmentNew);

            ViewBag.Success = "Appointment has been set.";

            return Redirect("/");
        }

    }
}
