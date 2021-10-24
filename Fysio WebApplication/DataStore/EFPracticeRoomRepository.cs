using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.DataStore
{
    public class EFPracticeRoomRepository : IPracticeRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public EFPracticeRoomRepository(ApplicationDbContext ctx)
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
