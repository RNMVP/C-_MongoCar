using MongoDBCars.Models;

namespace MongoDBCars.Repositories.CarRepo
{
    public interface ICarRepository
    {
        Task<Car?> FindById(string id);
        Task<List<Car>> FindAll();
        Task<List<Car>> FindByAnyThing(Action<Car> func);
        Task UpdateCar(string id, Car updatedCar);
        Task DeleteCar(string id);
        Task Create(Car car);

    }
}
