using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PracticeRoomService : IPracticeRoomService
    {
        private readonly IPracticeRoomRepository _practiceRoomRepository;

        public PracticeRoomService(IPracticeRoomRepository practiceRoomRepository)
        {
            _practiceRoomRepository = practiceRoomRepository;
        }

        public IQueryable<PracticeRoom> PracticeRooms => _practiceRoomRepository.PracticeRooms;

        public void Add(PracticeRoom entity)
        {
            _practiceRoomRepository.Add(entity);
        }

        public void AddPracticeRoom(PracticeRoom practiceRoom)
        {
            _practiceRoomRepository.AddPracticeRoom(practiceRoom);
        }

        public PracticeRoom FindByID(int ID)
        {
            return _practiceRoomRepository.FindByID(ID);
        }

        public IEnumerable<PracticeRoom> GetAll()
        {
            return _practiceRoomRepository.GetAll();
        }

        public PracticeRoom GetPracticeRoom(int id)
        {
            return _practiceRoomRepository.GetPracticeRoom(id);
        }

        public void Remove(PracticeRoom entity)
        {
            _practiceRoomRepository.Remove(entity);
        }

        public void Update(int id, PracticeRoom entity)
        {
            _practiceRoomRepository.Update(id, entity);
        }

        public void UpdatePracticeRoom(int id, PracticeRoom practiceRoom)
        {
            _practiceRoomRepository.UpdatePracticeRoom(id, practiceRoom);
        }
    }
}
