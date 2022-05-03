using PizzaOrders.Model;
using System;

namespace PizzaOrders
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddr { get; set; }

        public Pizza Pizza { get; set; }

        public bool IsDelivered { get; set; }
    }
}
