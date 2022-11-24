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
    public class OrdersRepository: IOrdersRepository
    {
        private readonly OrdersDbContext _context;

        public OrdersRepository(OrdersDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrdersModels>> GetAllOrders()
        {
            var orders = await _context.Orders.Select(x => new OrdersModels
            {
                OrderId = x.OrderId,
                BillingName= x.BillingName,
                Date=x.Date,
                PaymentStatus= x.PaymentStatus, 
                Total=x.Total,
                PaymentMethod= x.PaymentMethod,
                OrderStatus= x.OrderStatus,
            }).ToListAsync();
            return orders;
        }

        public async Task<OrdersModels> GetById(string orderId)
        {
            var records = await _context.Orders.Where(x => x.OrderId == orderId).Select(x => new OrdersModels
            {
                OrderId = x.OrderId,
                BillingName = x.BillingName,
                Date = x.Date,
                PaymentStatus = x.PaymentStatus,
                Total = x.Total,
                PaymentMethod = x.PaymentMethod,
                OrderStatus = x.OrderStatus,
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<string> AddOrderAsync(OrdersModels ordersModels)
        {
            var order = new Order()
            {
                OrderId = ordersModels.OrderId,
                BillingName = ordersModels.BillingName,
                Date = ordersModels.Date,
                PaymentStatus = ordersModels.PaymentStatus,
                Total = ordersModels.Total,
                PaymentMethod = ordersModels.PaymentMethod,
                OrderStatus = ordersModels.OrderStatus,
                CreatedDate = DateTime.Now,
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.OrderId;
        }

        public async Task UpdateOrderAsync(string OrderId, OrdersModels ordersModels)
        {
            var order = await _context.Orders.FindAsync(OrderId);
            if (order != null)
            {
                order.OrderId = ordersModels.OrderId;
                order.BillingName = ordersModels.BillingName;
                order.Date = ordersModels.Date;
                order.PaymentStatus = ordersModels.PaymentStatus;
                order.Total = ordersModels.Total;
                order.PaymentMethod = ordersModels.PaymentMethod;
                order.OrderStatus = ordersModels.OrderStatus;
                order.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateOrderPatchAsync(string OrderId, JsonPatchDocument ordersModel)
        {
            var order = await _context.Orders.FindAsync(OrderId);
            if (order != null)
            {
                ordersModel.ApplyTo(order);
                order.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(string orderId)
        {
            var order = new Order()
            {
                OrderId = orderId,
              
            };
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
