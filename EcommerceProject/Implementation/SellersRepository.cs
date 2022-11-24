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
    public class SellersRepository : ISellersRepository
    {
        private readonly SellersDbContext _context;

        public SellersRepository(SellersDbContext context)
        {
            _context = context;
        }

        public async Task<List<SellersModels>> GetAllSellers()
        {
            var orders = await _context.Sellers.Select(x => new SellersModels
            {
                SellerId = x.SellerId,
                SellerName = x.SellerName,
                Products = x.Products,
                WalletBalance = x.WalletBalance,
                Revenue = x.Revenue,
                Rating = x.Rating,
            }).ToListAsync();
            return orders;
        }
        public async Task<SellersModels> GetById(string sellerId)
        {
            var records = await _context.Sellers.Where(x => x.SellerId == sellerId).Select(x => new SellersModels
            {
                SellerId = x.SellerId,
                SellerName = x.SellerName,
                Products = x.Products,
                WalletBalance = x.WalletBalance,
                Revenue = x.Revenue,
                Rating = x.Rating,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<string> AddSellerAsync(SellersModels sellersModels)
        {
            var seller = new Seller()
            {
                SellerId = sellersModels.SellerId,
                SellerName = sellersModels.SellerName,
                Products = sellersModels.Products,
                WalletBalance = sellersModels.WalletBalance,
                Revenue = sellersModels.Revenue,
                Rating = sellersModels.Rating,
                CreatedDate = DateTime.Now,
            };
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return seller.SellerId;
        }

        public async Task UpdateSellerAsync(string SellerId, SellersModels sellersModels)
        {
            var seller = await _context.Sellers.FindAsync(SellerId);
            if (seller != null)
            {
                seller.SellerId = sellersModels.SellerId;
                seller.SellerName = sellersModels.SellerName;
                seller.Products = sellersModels.Products;
                seller.WalletBalance = sellersModels.WalletBalance;
                seller.Revenue = sellersModels.Revenue;
                seller.Rating = sellersModels.Rating;
                seller.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateSellerPatchAsync(string sellerId, JsonPatchDocument sellersModel)
        {
            var seller = await _context.Sellers.FindAsync(sellerId);
            if (seller != null)
            {
                sellersModel.ApplyTo(seller);
                seller.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSellerAsync(string sellerId)
        {
            var seller = new Seller()
            {
                SellerId = sellerId,
            };
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
        }
    }
}
