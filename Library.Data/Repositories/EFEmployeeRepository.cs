using Library.core.Model;
using Library.Data.Dal;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFEmployeeRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Employee> Employees => _context.Employees;

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> FindAll()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(string id)
        {
            // TODO: Temporarily added a toString on the new Id -W
            return _context.Employees.FirstOrDefault(i => i.Id.ToString() == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Update Employee
            _context.SaveChanges();
        }
    }
}
