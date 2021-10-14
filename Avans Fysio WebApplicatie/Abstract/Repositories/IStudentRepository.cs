using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }

        IEnumerable<Student> FindAll();

        Student GetStudent(int id);


    }
}
