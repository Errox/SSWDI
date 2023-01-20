using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;

namespace EFFysioData.Repositories
{
    public class EFAvailabilityRepository : EFGenericRepository<Availability>, IAvailabilityRepository
    {
        private readonly ApplicationDbContext _context;

        public EFAvailabilityRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }


        public IQueryable<Availability> Availabilities => _context.Availabilties;


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
