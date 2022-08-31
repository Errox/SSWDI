using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Library.Domain.Repositories
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
