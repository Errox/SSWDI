
using Library.core.Model;
using Library.DAL;
using Library.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly AppIdentityDbContext _context;

        public EFEmployeeRepository(AppIdentityDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Employee> Employees => _context.Users;

        public IEnumerable<Employee> FindAll()
        {
            return _context.Users;
        }

        public Employee GetEmployee(string id)
        {
            return _context.Users.FirstOrDefault(i => i.Id == id);
        }
    }
}
