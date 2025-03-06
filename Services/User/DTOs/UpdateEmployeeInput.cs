namespace MongoDBCars.Services.User.DTOs
{
    public record UpdateEmployeeInput(string Id, string Name, string Email, float Salary, string Position);
}
