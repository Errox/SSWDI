using Fysio_WebApplication.Areas.Identity.Data;
using Fysio_WebApplication.Data;
using Fysio_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.DataStore
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
