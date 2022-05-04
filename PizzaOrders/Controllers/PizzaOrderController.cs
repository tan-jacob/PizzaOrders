using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaOrderController : ControllerBase
    {
        private static readonly string[] Types = new[]
{
            "Cheese", "Pepperoni", "Hawaiian", "Canadian", "Vegetarian", "Meat Lovers"
        };

        private static readonly string[] Sizes = new[]
        {
            "Small", "Medium", "Large", "Extra Large"
        };

        private readonly PizzaOrderContext context;


        public PizzaOrderController(PizzaOrderContext context)
        {
            this.context = context;
        }

        //Get all orders
        //http://localhost:88888/pizzaorder
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            List<Order> orders = context.GetAllOrders();
            return Ok(orders);
        }

        //Get all pending orders
        //http://localhost:88888/pizzaorder/pending
        [HttpGet("pending")]
        public ActionResult<IEnumerable<Order>> GetAllPending()
        {
            IEnumerable<Order> pendingOrders = context.GetAllPendingOrders();
            if (pendingOrders == null)
            {
                return NotFound();
            }
            return Ok(pendingOrders);
        }

        //Get order by id
        //http://localhost:88888/{id}
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = context.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //Create a new order
        [HttpPost]
        public async Task<ActionResult> CreateOrder(string name, string addr)
        {
            Random rand = new Random();

            Order order = new Order
            {
                CustomerName = name,
                CustomerAddr = addr,
                IsDelivered = false,
                Pizza = Sizes[rand.Next(Sizes.Length)] + " " + Types[rand.Next(Types.Length)]
            };
            context.AddOrder(order);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
        }

        //Mark order as delivered
        [HttpPut("{id}")]
        public IActionResult MarkAsDelivered(int id)
        {
            var order = context.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                context.MarkOrderDelivered(order);
            }

            context.SaveChanges();
            return NoContent();
        }

        //Delete order
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = context.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                context.DeleteOrder(order);
            }

            context.SaveChanges();
            return NoContent();
        }

        //Loggers
        //private readonly ILogger<PizzaOrderController> _logger;

        //public PizzaOrderController(ILogger<PizzaOrderController> logger)
        //{
        //    _logger = logger;
        //}
    }
}
