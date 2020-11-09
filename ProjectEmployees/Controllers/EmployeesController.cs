using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ProjectEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBusiness _employee;
        public EmployeesController(IEmployeeBusiness employee)
        {
            _employee = employee;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            try
            {
                var lst_employees = await _employee.ListEmployees();
                return Ok(lst_employees);
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            try
            {
                var employee = await _employee.GetEmployee(id);
                return Ok(employee);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
