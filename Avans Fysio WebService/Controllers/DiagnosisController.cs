using Core.DomainModel;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Avans_Fysio_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosesService _diagnosesService;

        public DiagnosisController(IDiagnosesService diagnosesService)
        {
            _diagnosesService = diagnosesService;
        }

        // GET: DiagnosisController
        [HttpGet("")]
        public IEnumerable<Diagnosis> Get()
        {
            // Return everything
            return _diagnosesService.FindAll();
        }

        // GET: DiagnosisController/5
        [HttpGet("{code}")]
        public Diagnosis GetById(int code)
        {
            //return just the found int
            return _diagnosesService.GetDiagnosis(code);
        }
    }
}
