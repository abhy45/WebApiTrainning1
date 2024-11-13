using FirstExample_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstExample_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee{ ID = 123, EmpName ="Phaniraj", EmpAddress="Bangalore" },
            new Employee{ ID = 124, EmpName ="Tushar", EmpAddress="Noida" },
            new Employee{ ID = 125, EmpName ="Tarun", EmpAddress="New Delhi" }
        };

        [HttpGet("ListOfEmployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(employees);//use the status code to determine the kind of Status U wish to return as Response. 
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee emp)
        {
            var temp = employees.Find((e) => e.ID == emp.ID);
            if (temp == null)
                return BadRequest("Employee not found to update");
            temp.Assign(emp);
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var temp = employees.Find((e) => e.ID == id);
            if (temp == null)
                return BadRequest("Employee not found to delete");
            employees.Remove(temp);
            return Ok(employees);
        }

        [HttpPost("FindByNameAndId")]
        public async Task<ActionResult<List<Employee>>> GetEmployee([FromBody]EmpFinder finder)
        {
            var list = from emp in employees
                       where emp.EmpName == finder.EmpName && emp.ID == finder.EmpId
                       select emp;
            if (list.Count() == 0)
                return BadRequest("No employee found matching the details");
            return Ok(list.ToList());
        }
        [HttpGet("GetEmployee/{id}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var res = employees.Find((e) => e.ID == id);
            if (res == null)
                return BadRequest("Employee not found"); //Error when there is no valid emp..
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddNewEmployee(Employee emp)
        {
            employees.Add(emp);
            return Ok(employees);
        }
    }
}
