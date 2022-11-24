using Ecommerce.DataAccess.Contract;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productRepository.GetProductByIdAsync(id);
            return Ok(products);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] ProductModels productModels)
        {
            var id = await _productRepository.AddProductAsync(productModels);
            return CreatedAtAction(nameof(GetById), new { id = id, Controller = "prodct" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModels productModels, [FromRoute] int productId)
        {
            await _productRepository.UpdateProductAsync(productId, productModels);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductPatch([FromBody] JsonPatchDocument productModel, [FromRoute] int id)
        {
            await _productRepository.UpdateProductPatchAsync(id, productModel);
            return Ok();
        }
        [HttpDelete("{id}/{name}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id, [FromRoute] string name)
        {
            await _productRepository.DeleteProductAsync(id,name);
            return Ok();
        }
    }
}
