using Microsoft.AspNetCore.Mvc;
using TramposGestaoPedidosAPI.Entidades;


namespace TramposGestaoPedidosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly clsAppDbCRUD _context;

        public OrderItemController(clsAppDbCRUD context)
        {
            _context = context;
        }

        // GET: api/OrderItem
        [HttpGet]
        public IActionResult GetAll()
        {
            var orderItems = _context.OrderItems.ToList();
            return Ok(orderItems);
        }

        // GET: api/OrderItem/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null) return NotFound();
            return Ok(orderItem);
        }

        // GET: api/OrderItem/ByOrder/{orderId}
        [HttpGet("ByOrder/{orderId}")]
        public IActionResult GetByOrderId(int orderId)
        {
            var items = _context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
            return Ok(items);
        }

        // POST: api/OrderItem
        [HttpPost]
        public IActionResult Create([FromBody] OrderItem orderItem)
        {
            if (orderItem == null) return BadRequest();

            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = orderItem.Id }, orderItem);
        }

        // PUT: api/OrderItem/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id) return BadRequest();

            var existingOrderItem = _context.OrderItems.Find(id);
            if (existingOrderItem == null) return NotFound();

            existingOrderItem.ProductId = orderItem.ProductId;
            existingOrderItem.ProductName = orderItem.ProductName;
            existingOrderItem.Quantity = orderItem.Quantity;
            existingOrderItem.UnitPrice = orderItem.UnitPrice;
            existingOrderItem.TotalPrice = orderItem.TotalPrice;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/OrderItem/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null) return NotFound();

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
