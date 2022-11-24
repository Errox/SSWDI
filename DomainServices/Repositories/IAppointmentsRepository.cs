using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface IAppointmentsRepository : IGenericRepository<Appointment>
    {
        IQueryable<Appointment> Appointments { get; }
        Appointment GetAppointment(int id);
        void DeleteAppointment(int id);
        void UpdateAppointment(Appointment appointment);
        void AddAppointment(Appointment appointment);
        IEnumerable<Appointment> GetAppointmentsByPatientId(string patientId);
        IEnumerable<Appointment> GetAppointmentsByEmployeeId(string employeeId);
    }
}
