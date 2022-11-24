using Ecommerce.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Contract
{
  public interface IOrdersRepository
    {
        Task<List<OrdersModels>> GetAllOrders();
        Task<OrdersModels> GetById(string orderId);
        Task<string> AddOrderAsync(OrdersModels ordersModels);
        Task UpdateOrderAsync(string OrderId, OrdersModels ordersModels);
        Task UpdateOrderPatchAsync(string OrderId, JsonPatchDocument ordersModel);
        Task DeleteOrderAsync(string orderId);
    }
}