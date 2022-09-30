using Fysio_Codes.Abstract;
using Fysio_Codes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
