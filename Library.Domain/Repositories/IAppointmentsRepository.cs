using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Library.Domain.Repositories
{
    public interface IAppointmentsRepository
    {
        IQueryable<Appointment> Appointments { get; }
        IEnumerable<Appointment> FindAll();
        Appointment GetAppointment(int id);
        void DeleteAppointment(int id);
        void UpdateAppointment(Appointment appointment);
        void AddAppointment(Appointment appointment);
    }
}
