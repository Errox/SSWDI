using Core.DomainModel;
using DomainServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class PracticeRoomController : Controller
    {
        private IPracticeRoomService _service;

        public PracticeRoomController(IPracticeRoomService service)
        {
            _service = service;
        }

        [Authorize]
        // GET: PracticeRoomController
        public ActionResult Index()
        {
            return View(_service.PracticeRooms);
        }

        [Authorize]
        // GET: PracticeRoomController/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.PracticeRooms.FirstOrDefault(i => i.Id == id));
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: PracticeRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PracticeRoomController/Create
        [HttpPost]
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PracticeRoom practiceRoom)
        {
            try
            {
                _service.AddPracticeRoom(practiceRoom);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: PracticeRoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.GetPracticeRoom(id));
        }

        // POST: PracticeRoomController/Edit/5
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PracticeRoom practiceRoom)
        {
            try
            {
                _service.UpdatePracticeRoom(id, practiceRoom);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
