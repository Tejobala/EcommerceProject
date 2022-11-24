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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customersRepository.GetAllCustomers();
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var customer=await _customersRepository.GetById(id);
            return Ok(customer);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomersModels customersModels)
        {
            var id = await _customersRepository.AddCustomerAsync(customersModels);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = id, Controller = "customer" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomersModels customersModels, [FromRoute] string id)
        {
            await _customersRepository.UpdateCustomerAsync(id, customersModels);
            return Ok();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomerPatch([FromBody] JsonPatchDocument customerModel, [FromRoute] string id)
        {
            await _customersRepository.UpdateCustomerPatchAsync(id, customerModel);
            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] string id, [FromRoute] string name)
        {
            await _customersRepository.DeleteCustomerAsync(id,name);
            return Ok();
        }
    }
}
