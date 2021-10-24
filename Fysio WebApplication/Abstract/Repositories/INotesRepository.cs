using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.Abstract.Repositories
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
