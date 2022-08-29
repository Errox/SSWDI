using Avans_Fysio_WebService.Models;
using Microsoft.AspNetCore.Mvc;
using MainLibrary.DomainModel;
using System.Collections.Generic;

namespace Avans_Fysio_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosesRepository _diagnosesRepository;
        public DiagnosisController(IDiagnosesRepository diagnosesRepository)
        {
            _diagnosesRepository = diagnosesRepository;
        }

        // GET: DiagnosisController
        [HttpGet("")]
        public IEnumerable<Diagnosis> Get()
        {
            // Return everything
            return _diagnosesRepository.FindAll();
        }

        // GET: DiagnosisController/5
        [HttpGet("{code}")]
        public Diagnosis GetById(int code)
        {
            //return just the found int
            return _diagnosesRepository.GetDiagnosis(code);
        }
    }
}
