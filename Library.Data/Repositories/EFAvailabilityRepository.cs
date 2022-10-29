using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Repositories
{
    public class EFAvailabilityRepository : IAvailabilityRepository
    {
        private readonly ApplicationDbContext _context;

        public EFAvailabilityRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }


        public IQueryable<Availability> Availabilities => _context.Availabilties.Where(x => x.StartAvailability >= System.DateTime.Now.AddHours(1));

        public IEnumerable<Availability> FindAll()
        {
            return _context.Availabilties;
        }

        public Availability GetAvailability(int id)
        {
            return _context.Availabilties.FirstOrDefault(i => i.Id == id);
        }

        public void DeleteAvailability(int id)
        {
            Availability availability = _context.Availabilties.FirstOrDefault(i => i.Id == id);
            _context.Remove(availability);
            _context.SaveChanges();
        }

        public void UpdateAvailability(Availability availability)
        {
            _context.SaveChanges();
        }

        public void AddAvailability(Availability availability)
        {
            _context.Add(availability);
            _context.SaveChanges();
        }
    }
}
