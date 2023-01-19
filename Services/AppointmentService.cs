using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Appointment> Appointments => _appointmentsRepostory.Appointments.Where(a => a.TimeSlot.StartAvailability >= DateTime.Now);

        public void Add(Appointment appointment)
        {
            _appointmentsRepostory.Add(appointment);
        }

        // TODO: remove in future for generic repo.
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
    }
}
