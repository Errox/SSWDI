﻿using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Fysio_WebApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private IAvailabilityService _availabilityService;
        private IEmployeeService _employeeService;
        private IPatientService _patientService;
        private IAppointmentsService _appointmentService;

        public AppointmentController(
            IAvailabilityService availabilityService,
            IEmployeeService employeeService,
            IPatientService patientService,
            IAppointmentsService appointmentService)
        {
            _availabilityService = availabilityService;
            _employeeService = employeeService;
            _patientService = patientService;
            _appointmentService = appointmentService;
        }


        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: AppointmentController
        public ActionResult Index()
        {
            return View(_appointmentService.Appointments);
        }


        [Authorize(Policy = "RequirePatientRole")]
        // GET: AppointmentController/Create
        // This Create is for a patient to make a appointment with it's Therapist.
        public ActionResult Create()
        {
            // Here we get the patient into making a appointment with the doctor. 
            string Patient = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Patient currentlyLoggedIn = _patientService.GetPatientWithMedicalFile(Patient);
            
            if (currentlyLoggedIn.MedicalFile is null)
            {
                // access denied, no medicalfile yet. 
                return RedirectToAction("NoMedicalFile", "Error");
            }

            // Get all appointments from the patient. For this week. 
            List<Appointment> appointments = _appointmentService.GetAppointmentsByPatientId(currentlyLoggedIn.Id).ToList();

            List<Appointment> app = _appointmentService.GetAllPatientsAppointments(currentlyLoggedIn.Id);

            // Count the amount of treatments combined all into a int 
            ICollection<TreatmentPlan> treatmentplans = currentlyLoggedIn.MedicalFile.TreatmentPlans;
            int treatmentsPerWeek = 0;

            foreach (var treatmentplan in treatmentplans)
            {
                treatmentsPerWeek += treatmentplan.AmountOfTreatmentsPerWeek;
            }
            // Check if the amount of appointments that the patient has, are less then the treatmentplans prescribes.
            if (app.Count() <= treatmentsPerWeek)
            {
                IEnumerable<Availability> availability = _availabilityService.GetAvailabilityOfEmployee(currentlyLoggedIn.MedicalFile.IntakeTherapistId);

                SelectList selectlist = new SelectList(availability, "Id", "StartAvailability");

                ViewBag.Brands = new SelectList(_availabilityService.GetAvailabilityOfEmployee(currentlyLoggedIn.MedicalFile.IntakeTherapistId).ToList(), "Id", "StartAvailability");

                ViewBag.Patient = currentlyLoggedIn;
                ViewBag.Availability = availability;
                ViewBag.SelectList = selectlist;

                return View();
            }
            else
            {
                return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't create more appointments then the treatments prescribes." });
            }
        }

        [Authorize(Policy = "RequirePatientRole")]
        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection foFormCollection)
        {
            // Check if it's a patient. If it's a employee/student. Then it will be redirected to the CreateEmployeeAppointment.
            // We fetch the patient's id. And let them choose which time is best. We'll need the ID of the 
            var Id = Convert.ToInt32(foFormCollection["id"]);
            var availability = _availabilityService.FindByID(Id);

            string patient = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Patient currentlyLoggedIn = _patientService.GetPatientWithMedicalFile(patient);

            IEnumerable<Appointment> appointments = _appointmentService.GetAppointmentsByPatientId(currentlyLoggedIn.Id);
            ICollection<TreatmentPlan> treatmentplans = currentlyLoggedIn.MedicalFile.TreatmentPlans;
            if (treatmentplans.Count() == 0)
            {
                return RedirectToAction("IndexString", "Error", new { ErrorString = "You don't have any treatmentplans. You can't make a appointment yet." });
            }
            int treatmentsPerWeek = 0;
            foreach (var treatmentplan in treatmentplans)
            {
                treatmentsPerWeek += treatmentplan.AmountOfTreatmentsPerWeek;
            }

            // Check if the amount of appointments that the patient has, are less then the treatmentplans prescribes.
            if (appointments.Count() <= treatmentsPerWeek)
            {
                Appointment appointment = new Appointment();

                appointment.TimeSlot = availability;
                appointment.Patient = currentlyLoggedIn;
                appointment.Employee = currentlyLoggedIn.MedicalFile.IntakeTherapistId;


                availability.Patient = currentlyLoggedIn;
                availability.IsAvailable = false;

                _availabilityService.UpdateAvailability(availability);
                _appointmentService.AddAppointment(appointment);


                return RedirectToAction("Details", "Appointment");
            }
            else
            {
                return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't create more appointments then the treatment prescribes." });
            }

        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_appointmentService.GetAppointment(id));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]

        // POST: AppointmentController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Appointment collection)
        {
            try
            {
                Appointment appointment = _appointmentService.GetAppointment(id);
                //appointment.Date = collection.Date;
                _appointmentService.UpdateAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            string PatientId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            Appointment appointment = _appointmentService.GetAppointment(id);

            if (User.HasClaim("UserType", "Patient"))
            {
                // We need to check if the appointment is coming from the patient. 
                if (appointment is null)
                {
                    if(appointment.Patient.PatientId != PatientId)
                    {
                        // This aint the patient's appointment. Access Denied
                        return RedirectToAction("AccessDenied", "Account");
                    }
                }
            }

            // Redirect to medical file
            return View(_appointmentService.GetAppointment(id));
        }

        // POST: AppointmentController/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, Appointment collection)
        {
            // Delete for a appointment. 
            Appointment appointment = _appointmentService.FindAppointmentByIdWithTimeSlot(id);


            DateTime now = DateTime.Now;
            if (appointment.TimeSlot.StartAvailability <= now.AddHours(-24) && User.HasClaim("UserType", "Patient"))
            {
                // If the appointment is within 24 hours, we can't delete it. 
                return RedirectToAction("IndexString", "Error", new { ErrorString = "You can't remove a appointment within 24 hours of the appointment." });
            }

            // Get the availability and reset it back to use it for another patient.
            Availability availability = appointment.TimeSlot;
            availability.Patient = null;
            availability.IsAvailable = true;

            _availabilityService.UpdateAvailability(availability);

            _appointmentService.DeleteAppointment(appointment.Id);

            ViewBag.Success = "Appointment has been deleted.";
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = "RequirePatientRole")]
        public ActionResult Details()
        {
            List<Appointment> appointment = _appointmentService.GetAppointmentsByPatientId(this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            if (appointment is null || appointment.Count() == 0)
            {
                return RedirectToAction("Create", "Appointment");
            }

            if (appointment.Count() > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.StartTime = appointment.FirstOrDefault().TimeSlot.StartAvailability.ToString("t");
            ViewBag.StopTime = appointment.FirstOrDefault().TimeSlot.StopAvailability.ToString("t");
            ViewBag.Date = appointment.FirstOrDefault().TimeSlot.StartAvailability.ToString("d");
            return View(appointment);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: Appointment/Availability
        public ActionResult Availability()
        {
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        // POST: Appointment/Availability
        public ActionResult Availability(AvailabilityModel model)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _employeeService.GetEmployee(userId);

            if (model.DateTimeStart.Hour > model.DateTimeStop.Hour)
            {
                ModelState.AddModelError("", "You can't have a start time that is after the stop time.");
                return View(model);
            }

            if (model.DateStop < model.DateStart)
            {
                ModelState.AddModelError("", "You can't have a start date that is after the stop date.");
                return View(model);
            }

            DateTime DateStart = model.DateStart;

            while (DateStart < model.DateStop.AddDays(1))
            {
                DateTime startHour = model.DateTimeStart;
                while (startHour < model.DateTimeStop)
                {
                    DateTime CurrentDateTime = DateStart.AddHours(startHour.Hour).AddMinutes(startHour.Minute);
                    // add the availability to the database
                    _availabilityService.AddAvailability(new Availability
                    {
                        Employee = employee,
                        StartAvailability = CurrentDateTime,
                        StopAvailability = CurrentDateTime.AddMinutes(30), // We add 30 minutes because of a treatment takes a 30 minutes slot. 
                        IsAvailable = true
                    });
                    startHour = startHour.AddMinutes(30);// Here we add another 30 minutes, to start the next treatment. Slots of 30 minutes are there not only to treat te patient, but also to clean up, do administration, etc.
                }
                DateStart = DateStart.AddDays(1);
            }

            model.IsValid = ModelState.IsValid;
            return View(model);
        }

    }
}
