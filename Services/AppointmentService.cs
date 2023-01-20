using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentService : IAppointmentsService
    {

        private readonly IAppointmentsRepository _appointmentsRepostory;
        public AppointmentService(IAppointmentsRepository appointmentRepository)
        {
            _appointmentsRepostory = appointmentRepository;
        }

        public IQueryable<Appointment> Appointments => _appointmentsRepostory.Appointments
                .Where(a => a.TimeSlot.StartAvailability >= DateTime.Now)
                .Include(c1 => c1.Patient)
                    .ThenInclude(c1 => c1.ApplicationUser)
                .Include(c2 => c2.Employee)
                    .ThenInclude(c1 => c1.ApplicationUser)
                .Include(c3 => c3.TimeSlot);

        public void Add(Appointment appointment)
        {
            _appointmentsRepostory.Add(appointment);
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointmentsRepostory.Add(appointment);
        }

        public void DeleteAppointment(int id)
        {
            _appointmentsRepostory.DeleteAppointment(id);
        }

        public Appointment FindByID(int ID)
        {
            return _appointmentsRepostory.FindByID(ID);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentsRepostory.GetAll();
        }

        public List<Appointment> GetAllPatientsAppointments(string patientId)
        {
            return Appointments.Where(x => x.Patient.Id == patientId).ToList();
        }

        public Appointment GetAppointment(int id)
        {
            return _appointmentsRepostory.GetAppointment(id);
        }

        public IEnumerable<Appointment> GetAppointmentsByEmployeeId(string employeeId)
        {
            return Appointments
                .Include(x => x.Employee)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.MedicalFile)
                .Include(x => x.TimeSlot)
                .Where(a => a.Employee.EmployeeId == employeeId);

        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(string patientId)
        {
            return Appointments
                .Include(x => x.Employee)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.MedicalFile)
                .Include(x => x.TimeSlot)
                .Where(a => a.Patient.PatientId == patientId);
        }

        public void Remove(Appointment entity)
        {
            _appointmentsRepostory.Remove(entity);
        }

        public void Update(int id, Appointment entity)
        {
            _appointmentsRepostory.Update(id, entity);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _appointmentsRepostory.UpdateAppointment(appointment);
        }

        public Appointment FindAppointmentByIdWithTimeSlot(int id)
        {
            return Appointments
                .Include(x => x.TimeSlot)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Employee)
                    .ThenInclude(x => x.ApplicationUser)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Appointment> GetPatientAppointmentsDynamically(string userId)
        {
            return Appointments
                    .Include(x => x.Employee)
                        .ThenInclude(x => x.ApplicationUser)
                    .Include(x => x.Patient)
                        .ThenInclude(x => x.ApplicationUser)
                    .Include(x => x.Patient)
                        .ThenInclude(x => x.MedicalFile)
                    .Include(x => x.TimeSlot)
                    .Where(x => x.Patient.Id == userId || x.Patient.ApplicationUser.Id == userId).ToList();
        }

        public Appointment GetAppointmentByPatient(Patient patient)
        {
            return Appointments
                .FirstOrDefault(x => x.Patient == patient);
        }
    }
}
