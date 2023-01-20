using Core.DomainModel;
using DomainServices.Repositories;
using EFFysioData.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.Repositories
{
    public class EFEmployeeRepository : EFGenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _ctx;

        public EFEmployeeRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Employee> Employees => _ctx.Employees.Include(c1 => c1.ApplicationUser);

        public void AddEmployee(Employee employee)
        {
            _ctx.Employees.Add(employee);
            _ctx.SaveChanges();
        }

        public IEnumerable<Employee> FindAll()
        {
            return _ctx.Employees.Include(c1 => c1.ApplicationUser);
        }

        public Employee GetEmployee(string id)
        {
            return _ctx.Employees.Include(c1 => c1.ApplicationUser).FirstOrDefault(i => i.EmployeeId == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Update Employee
            _ctx.SaveChanges();
        }
    }
}
