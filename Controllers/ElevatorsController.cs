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
    public class ElevatorsController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public ElevatorsController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> GetElevators()
        {
            return await _context.Elevators.ToListAsync();
        }

        // GET: api/Elevators/5
         [HttpGet("non-operational")]
        public IEnumerable<Elevator> GetNonOperationalElevators()
        {
            IQueryable<Elevator> Elevators = from list_elev in _context.Elevators
                                             where list_elev.Status != "Active"
                                             select list_elev;

            return Elevators.ToList();
        }
        // PUT: api/Elevators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
        public async Task<IActionResult> PutmodifyElevatorsStatus(long id, [FromBody] Elevator body)
        {
            //check body 
            if (body.Status == null)
                return BadRequest();
            //find corresponding elevator 
            var elevator = await _context.Elevators.FindAsync(id);
            //change status 
            elevator.Status = body.Status;          
            try
            {
                //save change 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //catch error - elevetor doesn't exist 
                if (!ElevatorExists(id))
                    return NotFound();
                else
                    throw;
            }
            //return succeed message 
            return new OkObjectResult("success");
        }
               private bool ElevatorExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
