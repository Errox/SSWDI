using Library.core.Model;
using System.Collections.Generic;
using System.Linq;

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
        IEnumerable<Appointment> GetAppointmentsByPatientId(string patientId);
        IEnumerable<Appointment> GetAppointmentsByEmployeeId(string employeeId);
    }
}
