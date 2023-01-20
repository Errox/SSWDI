using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IQueryable<Employee> Employees => _employeeRepository.Employees;

        public void Add(Employee entity)
        {
            _employeeRepository.Add(entity);
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public Employee FindByID(int ID)
        {
            return _employeeRepository.FindByID(ID);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployee(string id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public void Remove(Employee entity)
        {
            _employeeRepository.Remove(entity);
        }

        public void Update(int id, Employee entity)
        {
            _employeeRepository.Update(id, entity);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
    }
}
