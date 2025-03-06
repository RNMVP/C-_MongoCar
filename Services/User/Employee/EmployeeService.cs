using AutoMapper;
using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Repositories.EmployeeRepo;
using MongoDBCars.Services.User.DTOs;
using EmployeeType = MongoDBCars.Models.users.Employee;

namespace MongoDBCars.Services.User.Employee
{
    public class EmployeeService(
        IEmployeeRepo employeeRepo,
        IMapper mapper
        ) : IEmployeeService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEmployeeRepo _employeeRepo = employeeRepo;
        public async Task<Result<EmployeeOutput>> Create(CreateEmployeeInput input)
        {
            var errors = new List<ApiError>();

            var CreateResult = EmployeeType.Create(input.Name, input.Email, input.Password, input.Salary, input.Position);
            if (CreateResult.ItsFailure) errors.AddRange(CreateResult.Errors);
            if (errors.Count > 0) return errors;
            
            var CreatedEmployee = CreateResult.Value;
            await _employeeRepo.Create(CreatedEmployee!);
            return _mapper.Map<EmployeeOutput>( CreatedEmployee );
        }

        public async Task<Result<EmployeeOutput>> DeleteById(string id)
        {
            List<ApiError> errors = [];

            var findedEmployee = await _employeeRepo.RequestById( id );
            if (findedEmployee is null)
            {
                errors.Add(ApiError.EMPLOYEE_NOT_FOUND);
                return errors;
            }

            await _employeeRepo.Delete(id);
            return _mapper.Map<EmployeeOutput>(findedEmployee);
        }

        public async Task<Result<List<EmployeeOutput>>> RequestAll()
        {
            var allEmployees = await _employeeRepo.Request();

            return _mapper.Map<List<EmployeeOutput>>( allEmployees );
        }

        public async Task<Result<EmployeeOutput>> RequestById(string id)
        {
            var errors = new List<ApiError>();
            var requestedEmployee = await _employeeRepo.RequestById(id);
            if( requestedEmployee is null )
            {
                errors.Add(ApiError.EMPLOYEE_NOT_FOUND);
                return errors;
            }
            return _mapper.Map<EmployeeOutput>(requestedEmployee);
        }

        public async Task<Result<EmployeeOutput>> Update(UpdateEmployeeInput input)
        {
            var errors = new List<ApiError>();

            var findedEmployee = await _employeeRepo.RequestById(input.Id);
            if (findedEmployee is null)
            {
                errors.Add(ApiError.EMPLOYEE_NOT_FOUND);
                return errors;
            }

            findedEmployee.Update(input.Name, input.Email, input.Salary, input.Position);
            await _employeeRepo.Update(input.Id, findedEmployee);

            return _mapper.Map<EmployeeOutput>(findedEmployee);
        }
    }
}
