using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevator_Foundation_REST.Models;

namespace Rocket_Elevator_Foundation_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;


        public EmployeesController(RailsApp_developmentContext context)
        {
            _context = context;
        }


        
        // GET: api/Employees
        [HttpGet("{email}")]
        public async Task<ActionResult<Employee>> GetEmployeeEmail(string email)
        {
            var _employees = await _context.Employees.ToListAsync();
           foreach (Employee employee in _employees)
            {
                if (employee.email == email)
                {
                return Ok(true);
                }
            }
            return Ok(false);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        private bool EmployeeExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
