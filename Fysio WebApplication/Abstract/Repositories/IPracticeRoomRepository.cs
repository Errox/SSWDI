using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Abstract.Repositories
{
    public interface IPracticeRoomRepository
    {
        IQueryable<PracticeRoom> PracticeRooms { get; }
        IEnumerable<PracticeRoom> FindAll();
        PracticeRoom GetPracticeRoom(int id);
        void UpdatePracticeRoom(PracticeRoom practiceRoom);
        void AddPracticeRoom(PracticeRoom practiceRoom);
    }
}
