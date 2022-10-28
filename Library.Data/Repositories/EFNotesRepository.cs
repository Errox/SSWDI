using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Repositories
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

        public void UpdateNote(int id, Note note)
        {
            Note note1 = _context.Notes.FirstOrDefault(i => i.Id == id);
            note1.Description = note.Description;
            note1.OpenForPatient = note.OpenForPatient;
            _context.SaveChanges();
        }

        public void AddNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
        }
    }
}
