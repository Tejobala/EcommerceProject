using Ecommerce.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Contract
{
    public interface IProductRepository
    {
        Task<List<ProductModels>> GetAll();
        Task<ProductModels> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(ProductModels productModel);
        Task UpdateProductAsync(int productId, ProductModels productModels);
        Task UpdateProductPatchAsync(int productId, JsonPatchDocument productModel);
        Task DeleteProductAsync(int productId, string name);
    }
}