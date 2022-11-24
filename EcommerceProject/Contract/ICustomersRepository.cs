using Ecommerce.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Contract
{
 public interface ICustomersRepository
    {
        Task<List<CustomersModels>> GetAllCustomers();
        Task<CustomersModels> GetById(string customerId);
        Task UpdateCustomerAsync(string customerId, CustomersModels customersModels);
        Task<string> AddCustomerAsync(CustomersModels customersModels);
        Task UpdateCustomerPatchAsync(string customerId, JsonPatchDocument productModel);
        Task DeleteCustomerAsync(string customerId, string name);
    }
}