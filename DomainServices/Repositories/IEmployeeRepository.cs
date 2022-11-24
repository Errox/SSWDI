using Core.DomainModel;

namespace DomainServices.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IQueryable<Employee> Employees { get; }
        Employee GetEmployee(string id);
        void UpdateEmployee(Employee employee);
        void AddEmployee(Employee employee);
    }
}