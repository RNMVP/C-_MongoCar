namespace MongoDBCars.Services.User.DTOs
{
    public record CreateCustomerInput(string Name, string Email, string Telephone, string Password);
}
