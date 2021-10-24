using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fysio_WebApplication.Areas.Identity.Data;
using Fysio_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fysio_WebApplication.DataStore
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }

        IEnumerable<Employee> FindAll();

        Employee GetEmployee(string id);
    }
}