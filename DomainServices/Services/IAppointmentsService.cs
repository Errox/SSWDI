using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface IAppointmentsService : IAppointmentsRepository
    {
        IEnumerable<Appointment> GetAppointmentsByPatientId(string patientId);
        IEnumerable<Appointment> GetAppointmentsByEmployeeId(string employeeId);

    }
}
