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
    public class BatteriesController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public BatteriesController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }
        [HttpGet("{BuildingId}")]
        public async Task<ActionResult<IEnumerable<long>>> BuildingBattery(string BuildingId)
        {
            var bat = await _context.Batteries.ToListAsync();
            var batteryList = new List<long>();

            foreach(Battery batteries in bat)
            {
                if(batteries.BuildingId.ToString()== BuildingId)
                {
                    batteryList.Add(batteries.Id);
                }
            }
            return batteryList;
        }

        // GET: api/Batteries/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Battery>> GetBattery(long id)
        // {
        //     var battery = await _context.Batteries.FindAsync(id);

        //     if (battery == null)
        //     {
        //         return NotFound();
        //     }

        //     return battery;
        // }

        // // PUT: api/Batteries/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutBattery(long id, Battery battery)
        // {
        //     if (id != battery.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(battery).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BatteryExists(id))
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

        // // POST: api/Batteries
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Battery>> PostBattery(Battery battery)
        // {
        //     _context.Batteries.Add(battery);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        // }

        // // DELETE: api/Batteries/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBattery(long id)
        // {
        //     var battery = await _context.Batteries.FindAsync(id);
        //     if (battery == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Batteries.Remove(battery);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool BatteryExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}
