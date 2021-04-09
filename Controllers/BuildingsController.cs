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
    public class BuildingsController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public BuildingsController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        // GET: api/Buildings/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Building>> GetBuilding(long id)
        // {
        //     var building = await _context.Buildings.FindAsync(id);

        //     if (building == null)
        //     {
        //         return NotFound();
        //     }

        //     return building;
        // }

        // // PUT: api/Buildings/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutBuilding(long id, Building building)
        // {
        //     if (id != building.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(building).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BuildingExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Buildings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        }

        // // DELETE: api/Buildings/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBuilding(long id)
        // {
        //     var building = await _context.Buildings.FindAsync(id);
        //     if (building == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Buildings.Remove(building);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        [HttpGet("{CustomerId}")]
        public async Task<ActionResult<IEnumerable<long>>> CustomerBuilding(string CustomerId, long Id)
        {
            var build = await _context.Buildings.ToListAsync();
            var buildingList = new List<long>();


            foreach(Building building in build)
            {
                if(building.CustomerId.ToString()== CustomerId)
                {
                    
                    buildingList.Add(building.Id);
                }
            }
            return buildingList;
        }
        private bool BuildingExists(long id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }

    }
}
