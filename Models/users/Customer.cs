using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using System.Collections.ObjectModel;

namespace MongoDBCars.Models.users
{
    public class Customer : User
    {
        public Collection<Car> Cars { get; set; } = [];

        private Customer() { }

        public Result<Customer> Create(string? name, string? email, string? password)
        {

            List<ApiError> errors = Validation(name, email, password);
            if (errors.Count > 0)
            {
                return errors;
            }

            Customer Customer = new()
            {
                Name = name!,
                Email = email!,
                Password = password!
            };
            return Customer;
        }
    }
}
