using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Models.users;
using MongoDBCars.Repositories.CustomerRepo;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Services.User
{
    public class CustomerService(ICustomerRepo customerRepo) : ICustomerService
    {
        ICustomerRepo _customerRepo = customerRepo;
        public async Task<Result<CustomerOutput>> Create(CreateCustomerInput input)
        {
            List<ApiError> errors = [];
            var customerResult = Customer.Create(input.Name, input.Email, input.Telephone, input.Password);
            
            if (customerResult.ItsFailure)
            {
                errors.AddRange(customerResult.Errors);
            }

            if (errors.Count > 0)
                return errors;

            var createdCustomer = customerResult.Value;

            await _customerRepo.Create(createdCustomer!);


        }

        public Task<Result<CustomerOutput>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<CustomerOutput>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result<CustomerOutput>> GetCustomerById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CustomerOutput>> Update(UpdateCustomerInput input)
        {
            throw new NotImplementedException();
        }
    }
}
