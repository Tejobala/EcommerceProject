using EcommerceProject.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.DataContext
{
    public class OrdersDbContext:DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> dbContextOptions):base(dbContextOptions) 
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
