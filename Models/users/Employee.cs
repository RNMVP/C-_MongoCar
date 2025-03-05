using MongoDBCars.DTOs;
using MongoDBCars.Enums;

namespace MongoDBCars.Models.users
{
    public class Employee: User
    {
        public float Salary { get; set; }
        public string Position { get; set; } = null!;

        public Employee() { }

        public Result<Employee> Create(
            string? name,
            string? email, 
            string? password,
            float? salary,
            string? position) 
        {
            List<ApiError> errors = Validation(name, email, password);
            errors.AddRange(CustomerValidation(salary, position));

            if (errors.Count > 0) 
            {
                return errors;
            }

            Employee employee = new()
            {
                Name = name!,
                Email = email!,
                HashedPassword = password!,
                Salary = (float) salary!,
                Position = Position!
            };

            return employee;
        }

        private List<ApiError> CustomerValidation(float? salary, string? position)
        {
            var errors = new List<ApiError>();

            if (salary == null) 
            {
                errors.Add(ApiError.SALARY_IS_REQUIRED);
            }
            if (salary < 0)
            {
                errors.Add(ApiError.NEGATIVE_SALARY);
            }
            if (String.IsNullOrEmpty(position))
            {
                errors.Add(ApiError.POSITION_IS_REQUIRED);
            }

            return errors;
        }
    }
}
