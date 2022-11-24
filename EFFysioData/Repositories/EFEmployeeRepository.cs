using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.Repositories
{
    public class EFEmployeeRepository : EFGenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFEmployeeRepository(ApplicationDbContext ctx) : base(ctx)
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
            return _context.Employees.Include(c1 => c1.ApplicationUser).FirstOrDefault(i => i.EmployeeId == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Update Employee
            _context.SaveChanges();
        }
    }
}
