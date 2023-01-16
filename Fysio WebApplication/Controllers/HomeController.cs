using Core.DomainModel;
using DomainServices.Repositories;
using Core.DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Fysio_WebApplication.ViewModels;

namespace Fysio_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAppointmentsRepository _appointmentRepository;

        public HomeController(ILogger<HomeController> logger, IAppointmentsRepository appointmentsRepository)
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
                var appointments = _appointmentRepository.Appointments
                    .Include(x => x.Employee)
                        .ThenInclude(x => x.ApplicationUser)
                    .Include(x => x.Patient)
                        .ThenInclude(x => x.ApplicationUser)
                    .Include(x => x.Patient)
                        .ThenInclude(x => x.MedicalFile)
                    .Include(x => x.TimeSlot)
                    .Where(x => x.Patient.Id == userId || x.Patient.ApplicationUser.Id == userId).ToList();

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
