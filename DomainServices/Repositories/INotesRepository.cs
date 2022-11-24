using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface INotesRepository : IGenericRepository<Note>
    {
        IQueryable<Note> Notes { get; }
        Note GetNote(int id);
        void UpdateNote(int id, Note note);
        void AddNote(Note note);
    }
}
