using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Enums.UserTypes;

namespace MongoDBCars.Models.users
{
    public class Employee: User
    {
        public float Salary { get; set; }
        public string Position { get; set; } = null!;

        public Employee() { }

        public static Result<Employee> Create(
            string? name,
            string? email, 
            string? password,
            float? salary,
            string? position) 
        {
            List<ApiError> errors = Validation(name, email, password, UserType.EMPLOYEE);
            errors.AddRange(EmployeeValidation(salary, position));

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
                Position = position!,
                UserType = UserType.EMPLOYEE
            };

            return employee;
        }

        public Result<Employee> Update(string name, string email, float salary, string position)
        {
            var errors = Validation(name, email, "", UserType.EMPLOYEE, true);
            errors.AddRange(EmployeeValidation(salary, position));
            if (errors.Count > 0) return errors;
            Name = name;
            Email = email;
            Salary = salary;
            Position = position;
            return this;
        }

        private static List<ApiError> EmployeeValidation(float? salary, string? position)
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
