using CarType = MongoDBCars.Models.Car;

namespace MongoDBCars.Services.User.DTOs
{
    public record CustomerOutput(string Name, string Email, List<CarType> Cars);
}
