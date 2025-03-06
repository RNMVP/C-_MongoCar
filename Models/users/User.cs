using MongoDBCars.Enums;
using MongoDBCars.Enums.UserTypes;
using MongoDBCars.Utils.Validations;

using BC = BCrypt.Net.BCrypt;

namespace MongoDBCars.Models.users
{
    public abstract class User : Entity<User>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public UserType UserType { get; set; }
        public User() { }

        protected static List<ApiError> Validation(string? name, string? email, string? password, UserType? userType, bool isUpdate=false)
        {
            List<ApiError> errors = [];

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add(ApiError.Customer_NAME_EMPTY);
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add(ApiError.CUSTOMER_EMAIL_EMPTY);
            }
            else
            {
                if (!email.IsValidEmail())
                {
                    errors.Add(ApiError.INVALID_EMAIL);
                }
            }
            if (userType is null) 
                errors.Add(ApiError.USER_TYPE_REQUIRED);
            else 
            {
                if (!Enum.IsDefined(typeof(UserType), userType))
                {
                    errors.Add(ApiError.USER_TYPE_NOT_DEFINED);
                }
            }
            if (!isUpdate)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    errors.Add(ApiError.PASSWORD_REQUIRED);
                }
                else
                {
                    if (!password.IsValidPassword())
                    {
                        errors.Add(ApiError.STRONG_PASSWORD_REQUIRED);
                    }
                }
            }
            return errors;
        }

        protected static string HashPassword(string password) 
        {
            return BC.HashPassword(password);
        }
    }
}
