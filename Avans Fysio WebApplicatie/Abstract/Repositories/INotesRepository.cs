using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
{
    public interface INotesRepository
    {
        IQueryable<Note> Notes { get; }
        IEnumerable<Note> FindAll();
        Note GetNote(int id);
        void UpdateNote(Note note);
        void AddNote(Note note);
    }
}
