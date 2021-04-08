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
    public class CustomerController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public CustomerController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers_email()
        {
            IQueryable<Customer> Customers = from list_cust in _context.Customers
                                             where list_cust.EmailOfCompanyContact != null
                                             select list_cust;

            return Customers.ToList();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

            // GET: api/Customers/Test@test.com
            [HttpGet("{email}")]
            public async Task<ActionResult<Customer>> GetCustomer(string email)
            {
            var _customers = await _context.Customers.ToListAsync();

            foreach (Customer customers in _customers)
            {
                if (customers.EmailOfCompanyContact == email)
                {
                return Ok(true);
                }
            }
            return Ok(false);
            }
            }
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        // {
        //     _context.Customers.Add(customer);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        // }

        // // DELETE: api/Customer/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCustomer(long id)
        // {
        //     var customer = await _context.Customers.FindAsync(id);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Customers.Remove(customer);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

