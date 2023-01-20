using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public IQueryable<Note> Notes => _notesRepository.Notes;

        public void Add(Note entity)
        {
            _notesRepository.Add(entity);
        }

        public void AddNote(Note note)
        {
            _notesRepository.AddNote(note);
        }

        public Note FindByID(int ID)
        {
            return _notesRepository.FindByID(ID);
        }

        public IEnumerable<Note> GetAll()
        {
            return _notesRepository.GetAll();
        }

        public Note GetNote(int id)
        {
            return _notesRepository.GetNote(id);
        }

        public void Remove(Note entity)
        {
            _notesRepository.Remove(entity);
        }

        public void Update(int id, Note entity)
        {
            _notesRepository.Update(id, entity);
        }

        public void UpdateNote(int id, Note note)
        {
            _notesRepository.UpdateNote(id, note);
        }
    }
}
