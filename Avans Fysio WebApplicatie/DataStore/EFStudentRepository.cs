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
    public class EFStudentRepository : IStudentRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFStudentRepository(WebApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Student> Students => throw new NotImplementedException();

        public IEnumerable<Student> FindAll()
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Student> Students => _context.Students;
        //public IEnumerable<Student> FindAll()
        //{
        //    return _context.Students;
        //}

        //public Student GetStudent(int id)
        //{
        //    return _context.Students.FirstOrDefault(i => i.Id == id);
        //}
    }
}
