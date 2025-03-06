using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Enums.UserTypes;
using System.Collections.ObjectModel;

namespace MongoDBCars.Models.users
{
    public class Customer : User
    {
        public string? Telephone { get; set; }
        public Collection<Car> Cars { get; set; } = [];

        private Customer() { }

        public static Result<Customer> Create(string? name, string? email, string? telephone, string? password)
        {

            List<ApiError> errors = Validation(name, email, password, UserType.CUSTOMER);
            if (errors.Count > 0)
                return errors;

            Customer Customer = new()
            {
                Name = name!,
                Email = email!,
                Telephone = telephone,
                HashedPassword = HashPassword(password!),
                UserType = UserType.CUSTOMER,
            };
            return Customer;
        }

        public Result<Customer> Update(string name, string email)
        {
            List<ApiError> errors = Validation(name, email, null, UserType.CUSTOMER, true);
            if(errors.Count > 0) return errors;

            Name = name;
            Email = email;

            return this;
        }
    }
}
