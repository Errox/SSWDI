using Avans_Fysio_WebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        // GET: TreatmentController
        [HttpGet("")]
        public IEnumerable<Treatment> Get()
        {
            // Return everything
            return _treatmentRepository.FindAll();
        }

        // GET: TreatmentController/5
        [HttpGet("{code}")]
        public Treatment GetById(string code)
        {
            return _treatmentRepository.GetTreatment(code);
        }
    }
}
