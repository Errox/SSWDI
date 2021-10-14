using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Abstract.Repositories;
using Avans_Fysio_WebApplicatie.Data;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.DataStore
{
    public class EFPracticeRoomRepository : IPracticeRoomRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFPracticeRoomRepository(WebApplicationDbContext ctx)
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

        public void UpdatePracticeRoom(PracticeRoom practiceRoom)
        {
            _context.SaveChanges();
        }

        //public void DeletePracticeRoom(PracticeRoom practiceRoom)
        //{
        //    context.Remove(practiceRoom);
        //}
    }
}
