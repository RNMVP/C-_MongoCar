using AutoMapper;
using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using CustomerType = MongoDBCars.Models.users.Customer;
using MongoDBCars.Repositories.CustomerRepo;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Services.User.Customer
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
            var customerResult = CustomerType.Create(input.Name, input.Email, input.Telephone, input.Password);

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

            if (errors.Count > 0) return errors;

            await _customerRepo.Delete(id);

            return _mapper.Map<CustomerOutput>(findedCustomer);

        }

        public async Task<Result<List<CustomerOutput>>> GetAll()
        {
            var allCustomers = await _customerRepo.Request();
            return _mapper.Map<List<CustomerOutput>>(allCustomers);
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

        public async Task<Result<CustomerOutput>> Update(UpdateCustomerInput input)
        {
            List<ApiError> errors = [];

            var findedCustomer = await _customerRepo.RequestById(input.Id);
            if (findedCustomer is null)
            {
                errors.Add(ApiError.CUSTOMER_NOT_FOUND);
                return errors;
            }

            var updateResponse = findedCustomer.Update(input.Name, input.Email);

            if (updateResponse.ItsFailure)
            {
                errors.AddRange(updateResponse.Errors);
            }

            if (errors.Count > 0)
            {
                return errors;
            }



            await _customerRepo.Update(input.Id, updateResponse.Value!);

            return _mapper.Map<CustomerOutput>(updateResponse.Value);
        }
    }
}
