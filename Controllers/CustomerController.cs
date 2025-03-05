using Microsoft.AspNetCore.Mvc;
using MongoDBCars.DTOs;
using MongoDBCars.Services.User;
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
    }
}
