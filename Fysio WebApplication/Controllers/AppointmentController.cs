﻿using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentsRepository _repo;

        public AppointmentController(IAppointmentsRepository repo)
        {
            _repo = repo;
        }
        // GET: AppointmentController
        public ActionResult Index()
        {
            return View(_repo.FindAll());
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

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

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetAppointment(id));
        }

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

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // POST: AppointmentController/Delete/5
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
