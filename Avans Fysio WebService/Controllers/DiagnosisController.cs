using Fysio_Codes.Abstract;
using Fysio_Codes.Models;
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
