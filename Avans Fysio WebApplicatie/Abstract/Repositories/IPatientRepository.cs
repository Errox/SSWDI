using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
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
