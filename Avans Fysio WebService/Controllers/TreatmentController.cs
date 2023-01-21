using Core.DomainModel;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Avans_Fysio_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        // GET: TreatmentController
        [HttpGet("")]
        public IEnumerable<Treatment> Get()
        {
            // Return everything
            return _treatmentService.FindAll();
        }

        // GET: TreatmentController/5
        [HttpGet("{code}")]
        public Treatment GetById(string code)
        {
            return _treatmentService.GetTreatment(code);
        }
    }
}
