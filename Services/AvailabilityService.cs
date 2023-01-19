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
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository= availabilityRepository;
        }

        public IQueryable<Availability> Availabilities => _availabilityRepository.Availabilities.Where(x => x.StartAvailability >= DateTime.Now.AddHours(1));

        public void Add(Availability entity)
        {
            _availabilityRepository.Add(entity);
        }

        public void AddAvailability(Availability availability)
        {
            _availabilityRepository.Add(availability);
        }

        public void DeleteAvailability(int id)
        {
            _availabilityRepository.DeleteAvailability(id);
        }

        public Availability FindByID(int ID)
        {
            return _availabilityRepository.FindByID(ID);
        }

        public IEnumerable<Availability> GetAll()
        {
            return _availabilityRepository.GetAll();
        }

        public Availability GetAvailability(int id)
        {
            return _availabilityRepository.GetAvailability(id);
        }

        public void Remove(Availability entity)
        {
            _availabilityRepository.Remove(entity);
        }

        public void Update(int id, Availability entity)
        {
            _availabilityRepository.Update(id, entity);
        }

        public void UpdateAvailability(Availability availability)
        {
            _availabilityRepository.UpdateAvailability(availability);
        }
    }
}
