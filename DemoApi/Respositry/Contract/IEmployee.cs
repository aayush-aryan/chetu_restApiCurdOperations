using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Respositry.Contract
{
   public interface IEmployee
    {
        //declearing a abstract method for getting Employee list;
        List<Employee> GetEmployees();

        //declearing a abstract method for creating Employee;
        Employee PostEmployee(Employee employee);

        // declearing abstract method for getting employee by Id;
        Employee GetEmployeeById(int id);
    }
}
