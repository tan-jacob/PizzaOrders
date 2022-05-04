using PizzaOrders.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddr { get; set; }

        public string Pizza { get; set; }

        public bool IsDelivered { get; set; }
    }
}
