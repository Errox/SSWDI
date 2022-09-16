using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.core.Model;
using Microsoft.AspNetCore.Mvc;

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