using AutoMapper;
using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Models.users;
using MongoDBCars.Repositories.CustomerRepo;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Services.User
{
    public class CustomerService(
        IMapper mapper,
        ICustomerRepo customerRepo) : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo = customerRepo;
        private readonly IMapper _mapper = mapper;
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

            return _mapper.Map<CustomerOutput>(createdCustomer);
        }

        public async Task<Result<CustomerOutput>> Delete(string id)
        {
            List<ApiError> errors = [];
            var findedCustomer = await _customerRepo.RequestById(id);
            if (findedCustomer is null)
                errors.Add(ApiError.CUSTOMER_NOT_FOUND);

            if(errors.Count > 0) return errors;

            await _customerRepo.Delete(id);

            return _mapper.Map<CustomerOutput>(findedCustomer);
            
        }

        public Task<Result<List<CustomerOutput>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<CustomerOutput>> GetCustomerById(string id)
        {
            List<ApiError> errors = [];
            var findedCustomer = await _customerRepo.RequestById(id);
            if (findedCustomer is null)
                errors.Add(ApiError.CUSTOMER_NOT_FOUND);

            if (errors.Count > 0) return errors;

            return _mapper.Map<CustomerOutput>(findedCustomer);
        }

        public Task<Result<CustomerOutput>> Update(UpdateCustomerInput input)
        {
            throw new NotImplementedException();
        }
    }
}
