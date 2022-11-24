using Core.DomainModel;
using DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class PracticeRoomController : Controller
    {
        private IPracticeRoomRepository _repo;

        public PracticeRoomController(IPracticeRoomRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        // GET: PracticeRoomController
        public ActionResult Index()
        {
            return View(_repo.PracticeRooms);
        }

        [Authorize]
        // GET: PracticeRoomController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.PracticeRooms.FirstOrDefault(i => i.Id == id));
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
                _repo.AddPracticeRoom(practiceRoom);
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
            return View(_repo.GetPracticeRoom(id));
        }

        // POST: PracticeRoomController/Edit/5
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PracticeRoom practiceRoom)
        {
            try
            {
                _repo.UpdatePracticeRoom(id, practiceRoom);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
