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
        
        public Employee DeleteEmployee(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
        }

        // for updating employee record
        //public Employee UpdateEmployee(Employee emp)
        //{
        //      // this one also update null value;
        //    dbContext.Employees.Update(emp);
        //    dbContext.SaveChanges();
        //    return emp;
        //}

        public Employee UpdateEmployee(Employee emp)
        {
            // for getting employee object
            var empObj = dbContext.Employees.SingleOrDefault(e => e.Id == emp.Id);
            if (empObj!=null)
            {
                //updating only all these four feilds or specific feild which we want
                empObj.FirstName = emp.FirstName;
                empObj.LastName = emp.LastName;
                empObj.Email = emp.Email;
                empObj.Address = emp.Address;

                dbContext.Employees.Update(emp);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
           
        }
    }
}
