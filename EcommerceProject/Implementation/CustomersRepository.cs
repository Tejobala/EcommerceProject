using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DataAccess.Contract;
using Ecommerce.DataAccess.DataContext;
using Ecommerce.Models;
using EcommerceProject.DataContext;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Implementation
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomersDbContext _context;

        public CustomersRepository(CustomersDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomersModels>> GetAllCustomers()
        {
            var customers = await _context.Customers.Select(x => new CustomersModels
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                PhoneNumber = x.PhoneNumber,
                Balance = x.Balance,
                Orders = x.Orders,
                LastOrdered = x.LastOrdered,
                Status = x.Status,
            }).ToListAsync();
            return customers;
        }
        public async Task<CustomersModels> GetById(string customerId)
        {
            var records = await _context.Customers.Where(x => x.CustomerId == customerId).Select(x => new CustomersModels
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                PhoneNumber = x.PhoneNumber,
                Balance = x.Balance,
                Orders = x.Orders,
                LastOrdered = x.LastOrdered,
                Status = x.Status,
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<string> AddCustomerAsync(CustomersModels customersModels)
        {
            var customer = new Customer()
            {
                CustomerId = customersModels.CustomerId,
                CustomerName = customersModels.CustomerName,
                PhoneNumber = customersModels.PhoneNumber,
                Balance = customersModels.Balance,
                Orders = customersModels.Orders,
                LastOrdered = customersModels.LastOrdered,
                Status = customersModels.Status,
                CreatedDate = DateTime.Now,
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.CustomerId;
        }
        public async Task UpdateCustomerAsync(string customerId, CustomersModels customersModels)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.CustomerId = customersModels.CustomerId;
                customer.CustomerName = customersModels.CustomerName;
                customer.PhoneNumber = customersModels.PhoneNumber;
                customer.Balance = customersModels.Balance;
                customer.Orders = customersModels.Orders;
                customer.LastOrdered = customersModels.LastOrdered;
                customer.Status = customersModels.Status;
                customer.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateCustomerPatchAsync(string customerId, JsonPatchDocument productModel)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                productModel.ApplyTo(customer);
                customer.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCustomerAsync(string customerId, string name)
        {
            var customer = new Customer()
            {
                CustomerId = customerId,
                CustomerName = name
            };
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}

