﻿using Avans_Fysio_WebService.GraphQL.ResponseTypes;
using Core.DomainModel;
using Core.GraphQL.ResponseTypes;
using DomainServices.Services;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class MedicalFileController : Controller
    {
        private IMedicalFileService _service;
        private IEmployeeService _employeeService;
        private IPatientService _patientService;
        private ITreatmentPlanService _treatmentPlanService;
        private INotesService _notesService;
        private IAppointmentsService _appointmentsService;
        private IAvailabilityService _availabilityService;
        private readonly IGraphQLClient _client;
        private IPracticeRoomService _practiceRoomService;

        public MedicalFileController(
            IMedicalFileService service,
            IEmployeeService employeeService,
            IPatientService patientService,
            ITreatmentPlanService treatmentPlanService,
            INotesService notesService,
            IAppointmentsService appointmentsService,
            IGraphQLClient client,
            IAvailabilityService availabilityService,
            IPracticeRoomService practiceRoomService)
        {
            _service = service;
            _employeeService = employeeService;
            _patientService = patientService;
            _treatmentPlanService = treatmentPlanService;
            _notesService = notesService;
            _appointmentsService = appointmentsService;
            _client = client;
            _availabilityService = availabilityService;
            _practiceRoomService = practiceRoomService;
        }

        [Authorize]
        // GET: MedicalFile
        public ActionResult Index()
        {
            var files = _service.GetMedicalFilesWithIntakeUsers();

            if (User.HasClaim("UserType", "Patient"))
            {
                Patient patient = _patientService.GetPatientWithMedicalFile(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (patient.MedicalFile is not null)
                {
                    return Redirect("/MedicalFile/Details/" + patient.MedicalFile.Id);
                }
                else
                {
                    return RedirectToAction("NoMedicalFile", "Error");
                }
            }
            return View(files);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult IndexPersonalSupervise()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(_service.GetMedicalFilesForIntakeSupervision(_employeeService.GetEmployee(userId)));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult IndexPersonalTherapist()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_service.GetMedicalFilesForTherapist(_employeeService.GetEmployee(userId)));
        }

        [Authorize]
        // GET: MedicalFile/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            MedicalFile medical = _service.GetDetailedMedicalFileById(id);

            //Fetch the diagnosis containing the code
            var client = new RestClient("https://fysiowebservice.azurewebsites.net/api");
            var request = new RestRequest("/Diagnosis/" + medical.DiagnosisCode, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Diagnosis diagnosis = JsonConvert.DeserializeObject<Diagnosis>(response.Content);
            //Send them towards the             

            ViewBag.BodyLocation = diagnosis.BodyLocation;
            ViewBag.Pathology = diagnosis.Pathology;

            if (User.HasClaim("UserType", "Employee") || User.HasClaim("UserType", "Student")) return View(_service.GetMedicalFile(id));


            if (User.HasClaim("UserType", "Patient"))
            {
                Patient patient = _patientService.GetPatientWithMedicalFile(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Check if the patient medicalfile is the same as the user
                if (patient.MedicalFile.Id == id) return View(_service.GetMedicalFile(id));
            }

            return RedirectToAction("AccessDenied", "Error");
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: MedicalFile/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            MedicalFile file = _service.GetMedicalFile(id);
            var query = new GraphQLRequest
            {
                Query = @"
                query GetAllDiag{
                  diagnoses {
                      id,
                      bodyLocation,
                      code,
                      pathology
                  }
                }"
            };

            var response = await _client.SendQueryAsync<ResponseDiagnosisCollectionType>(query);
            SelectList selectlist = new SelectList(response.Data.Diagnoses, "Code", "DisplayBodyAndPathology");

            var selected = selectlist.Where(x => x.Value == file.DiagnosisCode.ToString()).First();
            selected.Selected = true;

            ViewBag.Diagnoses = selectlist;
            return View(file);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // POST: MedicalFile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicalFile collection)
        {
            try
            {
                _service.UpdateMedicalFile(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public async Task<ActionResult> Create()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query GetAllDiag{
                  diagnoses {
                      id,
                      bodyLocation,
                      code,
                      pathology
                  }
                }"
            };

            var response = await _client.SendQueryAsync<ResponseDiagnosisCollectionType>(query);

            SelectList selectlist = new SelectList(response.Data.Diagnoses, "Code", "DisplayBodyAndPathology");

            ViewBag.Diagnoses = selectlist;
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        public ActionResult Create(MedicalFile file)
        {
            // Get the current logged in.
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //Create new plan because somehow it'll take the medicalFile ID and places it in the model instead of keeping it empty to insert in the DB
            MedicalFile medicalFile = new MedicalFile { Description = file.Description, DiagnosisCode = file.DiagnosisCode, DateOfDischarge = file.DateOfDischarge, DateOfCreation = DateTime.Now, PatientEmail = file.PatientEmail };

            Employee employee = _employeeService.GetEmployee(userId);

            if (employee.IsStudent)
            {
                //First employee that's not a student. This is just the stage begeleider
                medicalFile.IntakeSupervision = _employeeService.Employees.FirstOrDefault(i => i.IsStudent == false);
                // Then save the Student into the therapist. Only a employee that supervised over the patient is different when it's a student.
                medicalFile.IntakeTherapistId = employee;
            }
            else
            {
                medicalFile.IntakeSupervision = employee;
                medicalFile.IntakeTherapistId = employee;
            }

            _service.AddMedicalFile(medicalFile);

            //Return view
            return Redirect("/MedicalFile/Details/" + medicalFile.Id);
        }

        [Authorize]
        [Route("[Controller]/Notes/{id}")]
        public ActionResult Notes(int id)
        {
            // Check if the medicalfile from the patient has the same value as the userID. 
            if (User.HasClaim("UserType", "Patient"))
            {
                Patient patient = _patientService.GetPatientWithMedicalFile(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (patient.MedicalFile.Id != id) return RedirectToAction("AccessDenied", "Error");
            }


            MedicalFile file = _service.FindByID(id);

            if (User.HasClaim("UserType", "Patient") || User.HasClaim("UserType", "Student"))
            {
                if(file.Notes != null)
                {
                    return View(file.Notes.Where(x => x.OpenForPatient == true));
                }
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
                Employee = _employeeService.GetEmployee(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                Description = newNote.Description,
                CreatedUtc = DateTime.Now,
                OpenForPatient = newNote.OpenForPatient
            };

            _notesService.AddNote(note);

            //Add the Treatmentplan to the medicalFile
            MedicalFile medicalFile = _service.GetDetailedMedicalFileById(id);

            medicalFile.Notes.Add(note);
            _service.UpdateMedicalFile(id, medicalFile);

            //Return view
            return Redirect("/MedicalFile/Notes/" + id);
        }

        [Authorize]
        [Route("[Controller]/TreatmentPlan/{id}")]
        public ActionResult TreatmentPlan(int id)
        {
            // If user is patient. Then check if it's allowed to see the document
            // A patient can only watch it's own treatmentplans.
            if (User.HasClaim("UserType", "Patient"))
            {
                Patient patient = _patientService.GetPatientWithMedicalFile(User.FindFirstValue(ClaimTypes.NameIdentifier));

                if (patient.MedicalFile.Id != id) return RedirectToAction("AccessDenied", "Error");
            }

            // Return all TreatmentPlan for this medical File
            MedicalFile file = _service.GetDetailedMedicalFileById(id);


            ViewBag.Url = "/MedicalFile/" + file.Id + "/AddRoomTreatment/";
            return View(file.TreatmentPlans);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpGet]
        [Route("[Controller]/TreatmentPlanNew/{id}")]
        public async Task<ActionResult> TreatmentPlanNewAsync(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query GetAllTreat{
                  treatments {
                    code
                    description
                  }
                }"
            };

            var response = await _client.SendQueryAsync<ResponseTreatmentCollectionType>(query);

            SelectList selectlist = new SelectList(response.Data.Treatments, "Code", "Description");

            ViewBag.Treatments = selectlist;
            ViewBag.Url = "/MedicalFile/TreatmentPlanNew/" + id;

            MedicalFile medicalFile = _service.GetDetailedMedicalFileById(id);

            if (medicalFile.DateOfDischarge > DateTime.Now) return View();

            return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't make a new treatment when it's beyond discharge date." });

        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [Route("[Controller]/TreatmentPlanNew/{id}")]
        public ActionResult TreatmentPlanNew(int id, TreatmentPlan plan)
        {
            //Create new plan because somehow it'll take the medicalFile ID and places it in the model instead of keeping it empty to insert in the DB
            Employee employee = _employeeService.GetEmployee(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            TreatmentPlan NewPlan = new TreatmentPlan { Type = plan.Type, Description = plan.Description, Particularities = plan.Particularities, TreatmentPerformedBy = employee, TreatmentDate = plan.TreatmentDate, AmountOfTreatmentsPerWeek = plan.AmountOfTreatmentsPerWeek };

            MedicalFile medicalFile = _service.GetDetailedMedicalFileById(id);
            // check if medical file is beyond discharge date. 
            if (medicalFile.DateOfDischarge > DateTime.Now)
            {
                _treatmentPlanService.AddTreatmentPlan(NewPlan);

                //Add the Treatmentplan to the medicalFile
                medicalFile.TreatmentPlans.Add(NewPlan);
                _service.UpdateMedicalFile(id, medicalFile);
                //Return view
                return Redirect("/MedicalFile/TreatmentPlan/" + id);
            }
            return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't make a new treatment when it's beyond discharge date." });

        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpGet]
        [Route("[Controller]/{file}/AddRoomTreatment/{id}")]
        public ActionResult AddRoomTreatment(int file, int id)
        {
            ViewBag.Url = "/MedicalFile/" + file + "/AddRoomTreatment/" + id;
            ViewBag.Rooms = new SelectList(_practiceRoomService.GetAll(), "Id", "Name");
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [Route("[Controller]/{file}/AddRoomTreatment/{treatment}")]
        public ActionResult AddRoomTreatment(int file, int treatment, PracticeRoom Room)
        {
            //Add the Room to the 
            TreatmentPlan treatmentPlan = _treatmentPlanService.GetTreatmentPlan(treatment);
            PracticeRoom room = _practiceRoomService.GetPracticeRoom(Room.Id);
            treatmentPlan.PracticeRoom = room;

            _treatmentPlanService.UpdateTreatmentPlan(treatmentPlan.Id, treatmentPlan);

            //Return view
            return Redirect("/MedicalFile/TreatmentPlan/" + file);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public ActionResult Appointment(int id)
        {
            // getting the appointment that might be set on this medical file.
            Patient patient = _patientService.GetPatientByMedicalFile(id);

            if (patient is null)
            {
                ViewBag.Error = "Patient hasn't created a account yet. Please wait for the patient to create a account or make one.";
                return Redirect("/Auth/RegisterPatient/");
            }

            Appointment appointment = _appointmentsService.GetAppointmentByPatient(patient);

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
            Patient patient = _patientService.GetPatientByMedicalFile(id);
            // Here we get the patient into making a appointment with the doctor. 
            // Get all appointments from the patient. For this week. 
            IEnumerable<Appointment> appointments = _appointmentsService.GetAppointmentsByPatientId(patient.Id);
            // Count the amount of treatments combined all into a int 
            ICollection<TreatmentPlan> treatmentplans = patient.MedicalFile.TreatmentPlans;
            int treatmentsPerWeek = 0;
            foreach (var treatmentplan in treatmentplans)
            {
                treatmentsPerWeek = treatmentsPerWeek + treatmentplan.AmountOfTreatmentsPerWeek;
            }

            // Check if the amount of appointments that the patient has, are less then the treatmentplans prescribes.
            if (appointments.Count() <= treatmentsPerWeek)
            {
                Patient currentlyLoggedIn = _patientService.GetPatientWithMedicalFile(patient.PatientId);
                
                IEnumerable<Availability> availability = _availabilityService.GetAvailabilityOfEmployee(currentlyLoggedIn.MedicalFile.IntakeTherapistId);

                SelectList selectlist = new SelectList(availability, "Id", "StartAvailability");

                ViewBag.Brands = new SelectList(availability.ToList(), "Id", "StartAvailability");

                ViewBag.Patient = currentlyLoggedIn;
                ViewBag.Availability = availability;
                ViewBag.SelectList = selectlist;
                ViewBag.PostUrl = "/MedicalFile/AppointmentNew/" + id;


                return View();
            }
            else
            {
                return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't create more appointments then the treatment prescribes." });
            }


        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [Route("[Controller]/AppointmentNew/{medicalfileId}")]
        public ActionResult AppointmentNew(int medicalfileId, IFormCollection foFormCollection)
        {
            // A new appointment on this medical file / patient. 
            Patient patient = _patientService.GetPatientByMedicalFile(medicalfileId);
            // Here we get the patient into making a appointment with the doctor. 
            // Get all appointments from the patient. For this week. 
            IEnumerable<Appointment> appointments = _appointmentsService.GetAppointmentsByPatientId(patient.Id);
            // Count the amount of treatments combined all into a int 
            ICollection<TreatmentPlan> treatmentplans = patient.MedicalFile.TreatmentPlans;
            int treatmentsPerWeek = 0;
            foreach (var treatmentplan in treatmentplans)
            {
                treatmentsPerWeek += treatmentplan.AmountOfTreatmentsPerWeek;
            }

            // Check if the amount of appointments that the patient has, are less then the treatmentplans prescribes.
            if (appointments.Count() <= treatmentsPerWeek)
            {
                var Id = Convert.ToInt32(foFormCollection["id"]);
                Availability availability = _availabilityService.FindByID(Id);

                Patient currentlyLoggedIn = _patientService.GetPatientWithMedicalFile(patient.PatientId);

                Appointment appointment = new Appointment();

                appointment.TimeSlot = availability;
                appointment.Patient = currentlyLoggedIn;
                appointment.Employee = currentlyLoggedIn.MedicalFile.IntakeTherapistId;

                availability.Patient = currentlyLoggedIn;

                _availabilityService.UpdateAvailability(availability);
                _appointmentsService.AddAppointment(appointment);

                ViewBag.Success = "Appointment has been set.";

                return Redirect("/");
            }
            else
            {
                return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't create more appointments then the treatment prescribes." });
            }
        }

    }
}
