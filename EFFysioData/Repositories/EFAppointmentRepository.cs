using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.Repositories
{
    public class EFAppointmentRepository : EFGenericRepository<Appointment>, IAppointmentsRepository
    {
        private readonly ApplicationDbContext _context;

        public EFAppointmentRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        // Find all after today. 
        public IQueryable<Appointment> Appointments => _context.Appointments.Where(a => a.TimeSlot.StartAvailability >= DateTime.Now);
        public IEnumerable<Appointment> FindAll()
        {
            return _context.Appointments;
        }

        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.FirstOrDefault(i => i.Id == id);
        }

        public void DeleteAppointment(int id)
        {
            Appointment appointment = _context.Appointments.FirstOrDefault(i => i.Id == id);
            _context.Remove(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _context.SaveChanges();
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Add(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(string userId)
        {
            return _context.Appointments
                .Include(x => x.Employee)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.MedicalFile)
                .Include(x => x.TimeSlot)
                .Where(a => a.Patient.PatientId == userId);
        }

        public IEnumerable<Appointment> GetAppointmentsByEmployeeId(string employeeId)
        {
            return _context.Appointments
                .Include(x => x.Employee)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.MedicalFile)
                .Include(x => x.TimeSlot)
                .Where(a => a.Employee.EmployeeId == employeeId);
        }
    }
}
