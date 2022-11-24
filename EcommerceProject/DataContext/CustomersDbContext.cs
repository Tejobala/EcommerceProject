using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DataContext
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
