using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Abstract.Repositories;
using Avans_Fysio_WebApplicatie.Data;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.DataStore
{
    public class EFNotesRepository : INotesRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFNotesRepository(WebApplicationDbContext ctx)
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
