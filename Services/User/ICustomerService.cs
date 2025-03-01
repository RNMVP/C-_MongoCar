using MongoDBCars.DTOs;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Services.User
{
    public interface ICustomerService
    {
        Task<Result<CustomerOutput>> Create(CreateCustomerInput input);
        Task<Result<List<CustomerOutput>>> GetAll();
        Task<Result<CustomerOutput>> GetCustomerById(string id);
        Task<Result<CustomerOutput>> Update(UpdateCustomerInput input);
        Task<Result<CustomerOutput>> Delete(string id);
    }
}
