using Core.DomainModel;
using DomainServices.Repositories;

namespace DomainServices.Services
{
    public interface IAvailabilityService : IAvailabilityRepository
    {
        IEnumerable<Availability> GetAvailabilityOfEmployee(Employee employee);

    }
}
