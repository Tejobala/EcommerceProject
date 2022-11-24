using Ecommerce.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Contract
{
    public interface ISellersRepository
    {
        Task<List<SellersModels>> GetAllSellers();
        Task<SellersModels> GetById(string sellerId);

        Task<string> AddSellerAsync(SellersModels sellersModels);

        Task UpdateSellerAsync(string SellerId, SellersModels sellersModels);

        Task UpdateSellerPatchAsync(string sellerId, JsonPatchDocument sellersModel);

        Task DeleteSellerAsync(string sellerId);
    }
}