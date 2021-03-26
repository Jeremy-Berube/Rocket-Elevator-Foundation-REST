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
         public ActionResult<IEnumerable<Intervention>> Getinterventions()
        {
            List<Intervention> allInterventions = _context.Interventions.ToList();
            List<Intervention> pendingInterventions = new List<Intervention>();
            foreach(Intervention intervention in allInterventions) {
                if (intervention.intervention_start == null && intervention.Status == "Pending") {
                    pendingInterventions.Add(intervention);
                    Console.WriteLine(pendingInterventions.ToList());
                }
            }
            return pendingInterventions.ToList();
        }

        // // GET: api/Intervention/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Intervention>> GetIntervention(long id)
        // {
        //     var intervention = await _context.Interventions.FindAsync(id);

        //     if (intervention == null)
        //     {
        //         return NotFound();
        //     }

        //     return intervention;
        // }

        // PUT: api/Intervention/{id}/{status}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<Intervention>> StartIntervention(long id, string status)
        {
            if(status == "InProgress")
            {
                var intervention = await _context.Interventions.FindAsync(id);
                intervention.Status = status;
                intervention.intervention_start = DateTime.Now;
                // Console.WriteLine(intervention);
                await _context.SaveChangesAsync();
                Console.WriteLine(intervention.intervention_start);
                return intervention;
                // Console.WriteLine(intervention);
            }
            else if(status == "Completed")
            {
                var intervention = await _context.Interventions.FindAsync(id);
                intervention.Status = status;
                intervention.intervention_end = DateTime.Now;
                await _context.SaveChangesAsync();
                Console.WriteLine(intervention.intervention_end);
                return intervention;
            }
            return Ok("Invalid");
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
