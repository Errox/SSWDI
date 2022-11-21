using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
{
    public interface IAvailabilityRepository
    {
        IQueryable<Availability> Availabilities { get; }
        IEnumerable<Availability> FindAll();
        Availability GetAvailability(int id);
        void DeleteAvailability(int id);
        void UpdateAvailability(Availability availability);
        void AddAvailability(Availability availability);
    }
}
