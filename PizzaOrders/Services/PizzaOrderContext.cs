using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PizzaOrders.Model
{
    public class PizzaOrderContext : DbContext
    {
        public DbSet<Order> PizzaOrders { get; set; }
        public PizzaOrderContext(DbContextOptions options)
            : base(options)
        {
        }
       
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>().HasData(
        //        new Order
        //        {
        //            Id = 1,
        //            CustomerName = "Bob Joe",
        //            CustomerAddr = "123 Street",
        //            IsDelivered = false,
        //            Pizza = "Medium Cheese"
        //        },

        //        new Order
        //        {
        //            Id = 2,
        //            CustomerName = "Jim Don",
        //            CustomerAddr = "456 Street",
        //            IsDelivered = false,
        //            Pizza = "Large Pepperoni"
        //        },

        //        new Order
        //        {
        //            Id = 3,
        //            CustomerName = "Jon Doe",
        //            CustomerAddr = "789 Street",
        //            IsDelivered = true,
        //            Pizza = "Small Canadian"
        //        },

        //        new Order
        //        {
        //            Id = 4,
        //            CustomerName = "Jim Jon",
        //            CustomerAddr = "984 Street",
        //            IsDelivered = true,
        //            Pizza = "Medium Hawaiian"
        //        }
        //        );
        //}
        //Seed database
        public void LoadOrders()
        {
         
            PizzaOrders.Add(new Order
            {
                Id = 1,
                CustomerName = "Bob Joe",
                CustomerAddr = "123 Street",
                IsDelivered = false,
                Pizza = "Medium Cheese"
            });

            PizzaOrders.Add(new Order
            {
                Id = 2,
                CustomerName = "Jim Don",
                CustomerAddr = "456 Street",
                IsDelivered = false,
                Pizza = "Large Pepperoni"
            });

            PizzaOrders.Add(new Order
            {
                Id = 3,
                CustomerName = "Jon Doe",
                CustomerAddr = "789 Street",
                IsDelivered = true,
                Pizza = "Small Canadian"
            });

            PizzaOrders.Add(new Order
            {
                Id = 4,
                CustomerName = "Jim Jon",
                CustomerAddr = "984 Street",
                IsDelivered = true,
                Pizza = "Medium Hawaiian"
            });

        }

        public List<Order> GetAllOrders()
        {
            PizzaOrders.Load();
            return PizzaOrders.Local.ToList<Order>();
        }

        public IEnumerable<Order> GetAllPendingOrders()
        {
            PizzaOrders.Load();
            List<Order> orders = PizzaOrders.Local.ToList<Order>();
            IEnumerable<Order> pending = orders.Where(o => o.IsDelivered == false);
            return pending;
        }

        public Order GetOrderById(int id)
        {
            return PizzaOrders.Find(id);
        }
        
        public void AddOrder(Order order)
        {
            PizzaOrders.Load();
            order.Id = PizzaOrders.Local.Count + 1;

            PizzaOrders.Add(order);

        }

        public void MarkOrderDelivered(Order order)
        {
            order.IsDelivered = true;
        }

        public void DeleteOrder(Order order)
        {
            PizzaOrders.Remove(order);
        }
    }
}
