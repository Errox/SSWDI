using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;

namespace EFFysioData.Repositories
{
    public class EFNotesRepository : EFGenericRepository<Note>, INotesRepository
    {
        private readonly ApplicationDbContext _context;

        public EFNotesRepository(ApplicationDbContext ctx) : base(ctx)
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
