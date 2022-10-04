using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFEmployeeRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Employee> Employees => _context.Employees.Include(c1 => c1.ApplicationUser);

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> FindAll()
        {
            return _context.Employees.Include(c1 => c1.ApplicationUser);
        }

        public Employee GetEmployee(string id)
        {
            // TODO: Temporarily added a toString on the new Id -W
            return _context.Employees.Include(c1 => c1.ApplicationUser).FirstOrDefault(i => i.EmployeeId == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Update Employee
            _context.SaveChanges();
        }
    }
}
