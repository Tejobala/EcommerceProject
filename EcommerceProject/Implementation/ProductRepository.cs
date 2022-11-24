using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DataAccess.Contract;
using Ecommerce.DataAccess.DataContext;
using Ecommerce.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ecommerce.DataAccess.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task<List<ProductModels>> GetAll()
        {
            var products = await _productDbContext.Products.Select(x => new ProductModels
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Rating = x.Rating,
                Category = x.Category,
                AddedDate = x.AddedDate,
                Price = x.Price,
                Quantity = x.Quantity,
            }).ToListAsync();
            return products;
        }

        public async Task<ProductModels> GetProductByIdAsync(int productId)
        {
            var records = await _productDbContext.Products.Where(x => x.ProductId == productId).Select(x => new ProductModels
            {
                ProductId = x.ProductId,
                Rating = x.Rating,
                Category = x.Category,
                AddedDate = x.AddedDate,
                Price = x.Price,
                Quantity = x.Quantity,
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddProductAsync(ProductModels productModel)
        {
            var product = new Product()
            {
                ProductName = productModel.ProductName,
                Rating = productModel.Rating,
                Category = productModel.Category,
                AddedDate = DateTime.Now,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                CreatedDate = DateTime.Now,
            };
            _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync();
            return product.ProductId;
        }
        public async Task UpdateProductAsync(int productId, ProductModels productModels)
        {
            var product = await _productDbContext.Products.FindAsync(productId);
            if (product != null)
            {
                product.ProductName = productModels.ProductName;
                product.Rating = productModels.Rating;
                product.Category = productModels.Category;
                product.Price = productModels.Price;
                product.Quantity = productModels.Quantity;
                product.UpdatedDate = DateTime.Now;
                await _productDbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateProductPatchAsync(int productId, JsonPatchDocument productModel)
        {
            var product = await _productDbContext.Products.FindAsync(productId);
            if (product != null)
            {
                productModel.ApplyTo(product);
                product.UpdatedDate = DateTime.Now;
                await _productDbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteProductAsync(int productId, string name)
        {
            var product = new Product()
            {
                ProductId = productId,
                ProductName = name
            };
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
        }
    }
}