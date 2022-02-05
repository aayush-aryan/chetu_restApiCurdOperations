using DemoApi.Models;
using DemoApi.Respositry.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // injecting service in controller;
        private IEmployee employeeService;
        public EmployeesController(IEmployee employee)
        {
            employeeService = employee;
        }
        // for getting all Employees details
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var results = employeeService.GetEmployees();
            if (results.Count > 0)
            {
                return Ok(results);
            }
            else
            {
                return NotFound("Employee not found !");
            }
        }
        
        // getting employee detail by Id
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var results = employeeService.GetEmployeeById(id);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return NotFound("Employee not found !");
            }
        }

        // for creating employee
        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Post(Employee employee)
        {
           var result= employeeService.PostEmployee(employee);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                var result =employeeService.DeleteEmployee(id);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Update(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            else
            {
               var result = employeeService.UpdateEmployee(emp);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
