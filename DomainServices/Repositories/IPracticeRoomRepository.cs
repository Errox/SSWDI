using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface IPracticeRoomRepository : IGenericRepository<PracticeRoom>
    {
        IQueryable<PracticeRoom> PracticeRooms { get; }
        PracticeRoom GetPracticeRoom(int id);
        void UpdatePracticeRoom(int id, PracticeRoom practiceRoom);
        void AddPracticeRoom(PracticeRoom practiceRoom);
    }
}
