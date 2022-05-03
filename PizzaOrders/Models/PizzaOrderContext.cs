using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrders.Model
{
    public class PizzaOrderContext : DbContext
    {
        public PizzaOrderContext(DbContextOptions<PizzaOrderContext> options)
            : base(options)
        {

        }

        public DbSet<PizzaOrderContext> PizzaOrders { get; set; } = null;
    }
}
