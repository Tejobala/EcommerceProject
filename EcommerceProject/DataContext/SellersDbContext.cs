using EcommerceProject.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.DataContext
{
    public class SellersDbContext:DbContext
    {
        public SellersDbContext(DbContextOptions<SellersDbContext> dbContextOptions)
            :base(dbContextOptions) 
        {

        }
        public DbSet<Seller> Sellers { get; set; }
    }
}
