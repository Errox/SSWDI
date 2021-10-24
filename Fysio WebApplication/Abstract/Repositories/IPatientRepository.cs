using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Abstract.Repositories
{
    public interface IPatientRepository
    {
        IQueryable<Patient> Patients { get; }
        IEnumerable<Patient> FindAll();
        Patient GetPatient(int id);
        void UpdatePatient(int id, Patient patient);
        void AddPatient(Patient patient);
    }
}
