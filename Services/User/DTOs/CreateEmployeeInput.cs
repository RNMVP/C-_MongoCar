namespace MongoDBCars.Services.User.DTOs
{
    public record CreateEmployeeInput(string Name, string Email, string Password, float Salary, string Position);
}
