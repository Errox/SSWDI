using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Library.DAL;
using Library.Domain.Repositories;

namespace Library.Data
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
            // Getting all notes from a medical file.
            //ICollection<Note> notW2e = _context.MedicalFiles.FirstOrDefault(a => a.Id == id).Notes;

            _context.Add(note);
            _context.SaveChanges();
        }
    }
}
