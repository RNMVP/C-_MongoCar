using employeeType = MongoDBCars.Models.users.Employee;
using MongoDBCars.DTOs;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Services.User.Employee
{
    public interface IEmployeeService
    {
        Task<Result<EmployeeOutput>> Create(CreateEmployeeInput input);
        Task<Result<EmployeeOutput>> RequestById(string id);
        Task<Result<List<EmployeeOutput>>> RequestAll();
        Task<Result<EmployeeOutput>> Update(UpdateEmployeeInput input);
        Task<Result<EmployeeOutput>> DeleteById(string id);
    }
}
