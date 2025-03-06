using CarType = MongoDBCars.Models.Car;

namespace MongoDBCars.Services.User.DTOs
{
    public record CustomerOutput(string Id, string Name, string Email, List<CarType> Cars);
}
