﻿using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/{code}")]
        public IActionResult Index(int code)
        {
            ViewBag.ErrorCode = code;
            return View();
        }

        [Route("ErrorString")]
        public IActionResult IndexString(string ErrorString)
        {
            ViewBag.ErrorString = ErrorString;
            return View("Index");
        }

        [Route("Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("Account/NoMedicalFile")]
        public IActionResult NoMedicalFile()
        {
            return View();
        }
    }
}
