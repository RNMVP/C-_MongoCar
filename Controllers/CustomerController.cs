using Microsoft.AspNetCore.Mvc;
using MongoDBCars.DTOs;
using MongoDBCars.Services.User.Customer;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController(ICustomerService customerService): ControllerBase
    {
        readonly ICustomerService _customerService = customerService;

        [HttpPost]
        public async Task<ActionResult<Result<CustomerOutput>>> CreateCustomer([FromBody] CreateCustomerInput input)
        {
            var creationResult = await _customerService.Create(input);
            if (creationResult.ItsFailure) return BadRequest(ApiResponse<CustomerOutput>.GenerateFailure(creationResult.Errors));
            return CreatedAtAction(nameof(GetCustomer), new {id = creationResult.Value!.Id}, creationResult.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(string id)
        {
            var getResult = await _customerService.GetCustomerById(id);
            if(getResult.ItsFailure) return BadRequest(ApiResponse<CustomerOutput>.GenerateFailure(getResult.Errors));
            return Ok(ApiResponse<CustomerOutput>.GenerateSuccess(getResult.Value!));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            var getResult = await _customerService.GetAll();
            if(getResult.ItsFailure) return BadRequest(ApiResponse<List<CustomerOutput>>.GenerateFailure(getResult.Errors));
            return Ok(ApiResponse<List<CustomerOutput>>.GenerateSuccess(getResult.Value!));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerInput input)
        {
            var updateResult = await _customerService.Update(input);
            if(updateResult.ItsFailure) return BadRequest(ApiResponse<CustomerOutput>.GenerateFailure(updateResult.Errors));
            return Ok(ApiResponse<CustomerOutput>.GenerateSuccess(updateResult.Value!));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            var deleteResult = await _customerService.Delete(id);
            if(deleteResult.ItsFailure) return NotFound(ApiResponse<CustomerOutput>.GenerateFailure(deleteResult.Errors));
            return Ok(ApiResponse<CustomerOutput>.GenerateSuccess(deleteResult.Value!));
        }
    }
}
