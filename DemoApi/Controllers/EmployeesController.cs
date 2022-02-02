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
        // for getting Employee
        public IActionResult Get()
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

        // for creating employee
        [HttpPost]
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
    }
}
