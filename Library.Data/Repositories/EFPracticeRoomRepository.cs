﻿using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Repositories
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