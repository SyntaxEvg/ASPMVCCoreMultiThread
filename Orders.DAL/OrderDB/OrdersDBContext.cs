using Microsoft.EntityFrameworkCore;
using Orders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL.OrderDB
{
    public class OrdersDBContext: DbContext
    {
        public OrdersDBContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Buyers> Buyers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
