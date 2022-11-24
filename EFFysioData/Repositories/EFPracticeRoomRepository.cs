using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;

namespace EFFysioData.Repositories
{
    public class EFPracticeRoomRepository : EFGenericRepository<PracticeRoom>, IPracticeRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public EFPracticeRoomRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public IQueryable<PracticeRoom> PracticeRooms => _context.PracticeRooms;

        public void AddPracticeRoom(PracticeRoom practiceRoom)
        {
            _context.Add(practiceRoom);
            _context.SaveChanges();
        }

        public IEnumerable<PracticeRoom> FindAll()
        {
            return _context.PracticeRooms;
        }

        public PracticeRoom GetPracticeRoom(int id)
        {
            return _context.PracticeRooms.FirstOrDefault(i => i.Id == id);
        }

        public void UpdatePracticeRoom(int id, PracticeRoom practiceRoom)
        {
            PracticeRoom practice = _context.PracticeRooms.FirstOrDefault(i => i.Id == id);
            practice.Name = practiceRoom.Name;
            _context.SaveChanges();
        }

        //public void DeletePracticeRoom(PracticeRoom practiceRoom)
        //{
        //    context.Remove(practiceRoom);
        //}
    }
}
