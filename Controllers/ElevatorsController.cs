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
        [HttpGet("non-operational")]
        public IEnumerable<Elevator> GetElevators()
        {
            IQueryable<Elevator> Elevators = from list_elev in _context.Elevators
                                             where list_elev.Status != "Active"
                                             select list_elev;

            return Elevators.ToList();
        }

        [HttpGet("{ColumnId}")]
        public async Task<ActionResult<IEnumerable<long>>> BatteryColumn(string ColumnId)
        {
            var elev = await _context.Elevators.ToListAsync();
            var elevatorList = new List<long>();

            foreach(Elevator elevators  in elev)
            {
                if(elevators.ColumnId.ToString()== ColumnId)
                {
                    elevatorList.Add(elevators.Id);
                }
            }
            return elevatorList;
        }

         

        // GET: api/Elevators/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Elevator>> GetElevator(long id)
        // {
        //     var elevator = await _context.Elevators.FindAsync(id);

        //     if (elevator == null)
        //     {
        //         return NotFound();
        //     }

        //     return elevator;
        // }

        // PUT: api/Elevators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(long id, Elevator elevator)
        {
            if (id != elevator.Id)
            {
                return BadRequest();
            }

            _context.Entry(elevator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // // POST: api/Elevators
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Elevator>> PostElevator(Elevator elevator)
        // {
        //     _context.Elevators.Add(elevator);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetElevator", new { id = elevator.Id }, elevator);
        // }

        // // DELETE: api/Elevators/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteElevator(long id)
        // {
        //     var elevator = await _context.Elevators.FindAsync(id);
        //     if (elevator == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Elevators.Remove(elevator);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool ElevatorExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
