using Ecommerce.DataAccess.Contract;
using Ecommerce.DataAccess.Implementation;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellersRepository _sellersRepository;

        public SellerController(ISellersRepository sellersRepository)
        {
          _sellersRepository = sellersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _sellersRepository.GetAllSellers();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var orders = await _sellersRepository.GetById(id);
            return Ok(orders);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewSeller([FromBody] SellersModels sellersModels)
        {
            var id = await _sellersRepository.AddSellerAsync(sellersModels);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = id, Controller = "seller" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeller([FromBody] SellersModels sellersModels, [FromRoute] string id)
        {
            await _sellersRepository.UpdateSellerAsync(id, sellersModels);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSellerPatch([FromBody] JsonPatchDocument sellersModel, [FromRoute] string id)
        {
            await _sellersRepository.UpdateSellerPatchAsync(id, sellersModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
        {
            await _sellersRepository.DeleteSellerAsync(id);
            return Ok();
        }
    }
}
