using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Repositories
{
    public interface INotesRepository
    {
        IQueryable<Note> Notes { get; }
        IEnumerable<Note> FindAll();
        Note GetNote(int id);
        void UpdateNote(int id, Note note);
        void AddNote(Note note);
    }
}
