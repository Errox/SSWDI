using Fysio_WebApplication.Abstract.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    public class PracticeRoomController : Controller
    {
        private IPracticeRoomRepository _repo;

        public PracticeRoomController(IPracticeRoomRepository repo)
        {
            _repo = repo;
        }
        // GET: PracticeRoomController
        [Authorize]
        public ActionResult Index()
        {
            return View(_repo.PracticeRooms);
        }

        // GET: PracticeRoomController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.PracticeRooms.FirstOrDefault(i => i.Id == id));
        }

        // GET: PracticeRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PracticeRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PracticeRoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PracticeRoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PracticeRoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PracticeRoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
