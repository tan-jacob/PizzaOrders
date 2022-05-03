using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrders.Services;
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
        //Get all orders
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return PizzaOrderService.GetAll();
        }

        //Get order by id
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = PizzaOrderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }
            return order;
        }






        //Loggers
        private readonly ILogger<PizzaOrderController> _logger;

        public PizzaOrderController(ILogger<PizzaOrderController> logger)
        {
            _logger = logger;
        }
    }
}
