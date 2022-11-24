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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
          _ordersRepository = ordersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _ordersRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var customer = await _ordersRepository.GetById(id);
            return Ok(customer);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewOrder([FromBody] OrdersModels ordersModels)
        {
            var id = await _ordersRepository.AddOrderAsync(ordersModels);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = id, Controller = "Order" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] OrdersModels ordersModels, [FromRoute] string id)
        {
            await _ordersRepository.UpdateOrderAsync(id, ordersModels);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOrderPatch([FromBody] JsonPatchDocument orderModel, [FromRoute] string id)
        {
            await _ordersRepository.UpdateOrderPatchAsync(id, orderModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
        {
            await _ordersRepository.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
