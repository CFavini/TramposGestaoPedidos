using Microsoft.AspNetCore.Mvc;
using System;
using TramposGestaoPedidosAPI.Entidades;

namespace TramposGestaoPedidosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly clsAppDbCRUD _context;

        public CustomerController(clsAppDbCRUD context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (customer == null) return BadRequest();

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id) return BadRequest();

            var existingCustomer = _context.Customers.Find(id);
            if (existingCustomer == null) return NotFound();

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
