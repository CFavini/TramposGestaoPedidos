using Microsoft.AspNetCore.Mvc;
using TramposGestaoPedidosAPI.Entidades;

namespace TramposGestaoPedidosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly clsAppDbCRUD _context;

        public OrderController(clsAppDbCRUD context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null) return BadRequest();

            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (id != order.Id) return BadRequest();

            var existingOrder = _context.Orders.Find(id);
            if (existingOrder == null) return NotFound();

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.Status = order.Status;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
