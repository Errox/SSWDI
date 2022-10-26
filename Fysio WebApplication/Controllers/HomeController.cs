﻿using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace Fysio_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAppointmentsRepository _appointmentRepository;

        public HomeController(ILogger<HomeController> logger, IAppointmentsRepository appointmentsRepository )
        {
            _logger = logger;
            _appointmentRepository = appointmentsRepository;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.HasClaim("UserType", "Employee") || User.HasClaim("UserType", "Student"))
            {
                var appointments = _appointmentRepository.GetAppointmentsByEmployeeId(userId);
                var appointmentNow = appointments.Where(x => x.TimeSlot.StartAvailability.ToString("d") == System.DateTime.Now.ToString("d"));
                var appointmentNext = appointments.Where(x => x.TimeSlot.StartAvailability > System.DateTime.Now);
                ViewBag.AppointmentsNow = appointmentNow;
                ViewBag.AppointmentsNext = appointmentNext;
                ViewBag.AppointmentsNowCount = appointmentNow.Count();
                ViewBag.AppointmentsNextCount = appointmentNext.Count();

                return View();
            }
            
            if (User.HasClaim("UserType", "Patient"))
            {
                var appointments = _appointmentRepository.GetAppointmentsByPatientId(userId);
                var appointmentNow = appointments.Where(x => x.TimeSlot.StartAvailability.ToString("d") == System.DateTime.Now.ToString("d"));
                var appointmentNext = appointments.Where(x => x.TimeSlot.StartAvailability > System.DateTime.Now);
                ViewBag.AppointmentsNow = appointmentNow;
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
