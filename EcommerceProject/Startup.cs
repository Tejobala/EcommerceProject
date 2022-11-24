using Ecommerce.DataAccess.Contract;
using Ecommerce.DataAccess.DataContext;
using Ecommerce.DataAccess.Implementation;
using EcommerceProject.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
           services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<ISellersRepository, SellersRepository>();


            services.AddDbContext<ProductDbContext>(option=>option.UseSqlServer(Configuration.GetConnectionString("ProductDb")));
          services.AddDbContext<CustomersDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("CustomerDb")));
            services.AddDbContext<OrdersDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("OrderDb")));
            services.AddDbContext<SellersDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("SellerDb")));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcommerceProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
