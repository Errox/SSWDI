using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface IAvailabilityRepository : IGenericRepository<Availability>
    {
        IQueryable<Availability> Availabilities { get; }
        Availability GetAvailability(int id);
        void DeleteAvailability(int id);
        void UpdateAvailability(Availability availability);
        void AddAvailability(Availability availability);
    }
}
