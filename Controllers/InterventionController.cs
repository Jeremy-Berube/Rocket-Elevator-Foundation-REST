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
    public class InterventionController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public InterventionController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Intervention
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Intervention/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }

        // PUT: api/Intervention/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervention(long id, Intervention intervention)
        {
            if (id != intervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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

        // POST: api/Intervention
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Intervention>> PostIntervention(Intervention intervention)
        // {
        //     _context.Interventions.Add(intervention);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetIntervention", new { id = intervention.Id }, intervention);
        // }

        // // DELETE: api/Intervention/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteIntervention(long id)
        // {
        //     var intervention = await _context.Interventions.FindAsync(id);
        //     if (intervention == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Interventions.Remove(intervention);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool InterventionExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
