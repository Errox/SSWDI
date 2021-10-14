using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Abstract.Repositories;
using Avans_Fysio_WebApplicatie.Data;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.DataStore
{
    public class EFAppointmentRepository : IAppointmentsRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFAppointmentRepository(WebApplicationDbContext ctx)
        {
            _context = ctx;
        }


        public IQueryable<Appointment> Appointments => _context.Appointments;
        public IEnumerable<Appointment> FindAll()
        {
            return _context.Appointments;
        }

        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.FirstOrDefault(i => i.Id == id);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _context.Remove(Appointments);
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
    }
}
