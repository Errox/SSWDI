using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
{
    public interface IPracticeRoomRepository
    {
        IQueryable<PracticeRoom> PracticeRooms { get; }
        IEnumerable<PracticeRoom> FindAll();
        PracticeRoom GetPracticeRoom(int id);
        void UpdatePracticeRoom(int id, PracticeRoom practiceRoom);
        void AddPracticeRoom(PracticeRoom practiceRoom);
    }
}
