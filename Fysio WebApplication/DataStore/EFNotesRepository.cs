using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Abstract.Repositories;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;

namespace Fysio_WebApplication.DataStore
{
    public class EFNotesRepository : INotesRepository
    {
        private readonly ApplicationDbContext _context;

        public EFNotesRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Note> Notes => _context.Notes;

        public IEnumerable<Note> FindAll()
        {
            return _context.Notes;
        }

        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateNote(Note note)
        {
            _context.SaveChanges();
        }

        public void AddNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
        }
    }
}
