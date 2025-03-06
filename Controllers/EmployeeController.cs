using Microsoft.AspNetCore.Mvc;
using MongoDBCars.DTOs;
using MongoDBCars.Services.User.DTOs;
using MongoDBCars.Services.User.Employee;

namespace MongoDBCars.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController(IEmployeeService employeeService): ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeInput input) 
        {
            var createResult = await _employeeService.Create(input);
            if (createResult.ItsFailure) return BadRequest(ApiResponse<EmployeeOutput>.GenerateFailure(createResult.Errors));
            return CreatedAtAction(nameof(GetEmployeeById), new {id = createResult.Value!.Id}, createResult.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(string id)
        {
            var requestResult = await _employeeService.RequestById(id);
            if(requestResult.ItsFailure) return NotFound(ApiResponse<EmployeeOutput>.GenerateFailure(requestResult.Errors));
            return Ok(ApiResponse<EmployeeOutput>.GenerateSuccess(requestResult.Value!));
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployee() 
        {
            var requestResult = await _employeeService.RequestAll();
            if (requestResult.ItsFailure) return NotFound(ApiResponse<EmployeeOutput>.GenerateFailure(requestResult.Errors));
            return Ok(requestResult.Value);
        }
    }
}
