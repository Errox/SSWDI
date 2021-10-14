using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
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
