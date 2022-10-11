using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private IAppointmentsRepository _repo;

        public AppointmentController(IAppointmentsRepository repo)
        {
            _repo = repo;
        }


        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: AppointmentController
        public ActionResult Index()
        {
            return View(_repo.Appointments.Include(c1 => c1.Patient).Include(c2 => c2.Employee));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment collection)
        {
            try
            {
                _repo.AddAppointment(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Appointment collection)
        {
            try
            {
                Appointment appointment = _repo.GetAppointment(id);
                appointment.Date = collection.Date;
                _repo.UpdateAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // POST: AppointmentController/Delete/5
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Appointment collection)
        {
            try
            {
                _repo.DeleteAppointment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
