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
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        }

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
            System.Console.WriteLine(buildingList);
            return buildingList;
        }
        private bool BuildingExists(long id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }

    }
}
