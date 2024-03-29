﻿using Core.DomainModel;
using DomainServices.Repositories;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Fysio_WebApplication.ViewModels;
using DomainServices.Services;

namespace Fysio_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAppointmentsService _appointmentService;

        public HomeController(ILogger<HomeController> logger, IAppointmentsService appointmentsService)
        {
            _logger = logger;
            _appointmentService = appointmentsService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.HasClaim("UserType", "Employee") || User.HasClaim("UserType", "Student"))
            {
                var appointments = _appointmentService.GetAppointmentsByEmployeeId(userId);
                List<Appointment> appointmentNow = appointments.Where(x => x.TimeSlot.StopAvailability.ToString("d") == System.DateTime.Now.ToString("d")).ToList();
                List<Appointment> appointmentNext = appointments.Where(x => x.TimeSlot.StartAvailability > System.DateTime.Now.AddDays(1)).ToList();
                ViewBag.AppointmentsNow = appointmentNow.Where(x => x.TimeSlot.StartAvailability >= System.DateTime.Now).ToList();
                ViewBag.AppointmentsNext = appointmentNext;
                ViewBag.AppointmentsNowCount = appointmentNow.Count();
                ViewBag.AppointmentsNextCount = appointmentNext.Count();

                return View();
            }

            if (User.HasClaim("UserType", "Patient"))
            {
                var appointments = _appointmentService.GetPatientAppointmentsDynamically(userId);

                List<Appointment> appointmentNow = appointments.Where(x => x.TimeSlot.StopAvailability.ToString("d") == System.DateTime.Now.ToString("d")).ToList();
                List<Appointment> appointmentNext = appointments.Where(x => x.TimeSlot.StartAvailability > System.DateTime.Now.AddDays(1)).ToList();
                ViewBag.AppointmentsNow = appointmentNow.Where(x => x.TimeSlot.StartAvailability >= System.DateTime.Now).ToList();
                ViewBag.AppointmentsNext = appointmentNext;
                ViewBag.AppointmentsNowCount = appointmentNow.Count();
                ViewBag.AppointmentsNextCount = appointmentNext.Count();
                return View();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Appointments()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
