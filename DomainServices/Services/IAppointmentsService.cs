using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface IAppointmentsService : IAppointmentsRepository
    {
        IEnumerable<Appointment> GetAppointmentsByPatientId(string patientId);
        IEnumerable<Appointment> GetAppointmentsByEmployeeId(string employeeId);
        List<Appointment> GetAllPatientsAppointments(string patientId);
        Appointment FindAppointmentByIdWithTimeSlot(int id);
        List<Appointment> GetPatientAppointmentsDynamically(string userId);
        Appointment GetAppointmentByPatient(Patient patient);

    }
}
