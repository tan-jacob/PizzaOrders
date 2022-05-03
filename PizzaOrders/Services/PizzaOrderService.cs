using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOrders.Model;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrders.Services
{
    public class PizzaOrderService
    {
        //List acts as a database of orders
        static List<Order> Orders { get; }

        static int nextId = 3;

        static PizzaOrderService()
        {
            Orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerName = "Bob Joe", CustomerAddr = "123 Street", IsDelivered = false, OrderDate = DateTime.Now,
                            Pizza = new Pizza { Type = "Cheese", Size ="Medium" } },
                new Order { OrderID = 2, CustomerName = "Jim Don", CustomerAddr = "456 Street", IsDelivered = false, OrderDate = DateTime.Now,
                            Pizza = new Pizza { Type = "Pepperoni", Size ="Large" } },
            };
        }

        public static List<Order> GetAll() => Orders;

        public static Order Get(int id) => Orders.FirstOrDefault(o => o.OrderID == id);

        public static void Add(Order order)
        {
            order.OrderID = nextId++;
            Orders.Add(order);
        }

    }
}
