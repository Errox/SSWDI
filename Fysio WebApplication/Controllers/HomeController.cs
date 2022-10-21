using Library.core.Model;
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
                var appointment = _appointmentRepository.GetAppointmentsByEmployeeId(userId);
                ViewBag.Appointments = appointment;
                ViewBag.Count = appointment.Count();
                
                return View();
            }
            if (User.HasClaim("UserType", "Patient"))
            {
                return View(_appointmentRepository.GetAppointmentsByPatientId(userId));
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
