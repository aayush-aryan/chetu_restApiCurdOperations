using DemoApi.Models;
using DemoApi.Respositry.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Respositry.Service
{
    public class EmployeeService : IEmployee
    {
       private readonly ApplicationDbContext dbContext;
        // Injecting ApplicationDbContext class
          public EmployeeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //returning single employee from list;
        public Employee GetEmployeeById(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            return emp;
        }
        //returning all employee list
        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        //for adding employee in list;
        public Employee PostEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }
    }
}
