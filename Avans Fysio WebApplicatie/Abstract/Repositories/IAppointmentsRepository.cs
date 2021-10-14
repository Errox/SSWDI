using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
{
    public interface IAppointmentsRepository
    {
        IQueryable<Appointment> Appointments { get; }
        IEnumerable<Appointment> FindAll();
        Appointment GetAppointment(int id);
        void DeleteAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void AddAppointment(Appointment appointment);
    }
}
