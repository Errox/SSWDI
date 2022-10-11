using Library.core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }
        IEnumerable<Employee> FindAll();
        Employee GetEmployee(string id);
        void UpdateEmployee(Employee employee);
        void AddEmployee(Employee employee);
    }
}