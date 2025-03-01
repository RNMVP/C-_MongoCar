
using MongoDBCars.DTOs;
using MongoDBCars.Enums;
using MongoDBCars.Repositories.CarRepo;
using CarType = MongoDBCars.Models.Car;

namespace MongoDBCars.Services.Car
{
    public class CarService(ICarRepository carRepository) : ICarService
    {

        private readonly ICarRepository _carRepository = carRepository;

        public async Task<Result<CarType>> CreateCar(string? brand, string? carPlate, string? color)
        {
            var newCarResult = CarType.Create(brand, carPlate, color);
            if (newCarResult.ItsFailure)
            {
                return newCarResult.Errors;
            }
            else
            {
                var newCar = newCarResult.Value;
                await _carRepository.Create(newCar!);
                return newCar!;
            }
        }

        public async Task DeleteCar(string carId)
        {
            await _carRepository.DeleteCar(carId);
        }

        public async Task<Result<List<CarType>>> FindAllCars() => await _carRepository.FindAll();

        public async Task<Result<CarType>> UpdateCar(string carId, string? carPlate, string? color)
        {

            List<ApiError> errors = [];

            var foundedCar = await _carRepository.FindById(carId);
            if (foundedCar == null)
            {
                errors.Add(ApiError.CAR_NOT_FOUND_ID);
                return errors;
            }

            var carEditedResult = foundedCar.Edit(foundedCar.Brand, carPlate, color);

            if (carEditedResult.ItsFailure) errors.AddRange(carEditedResult.Errors);

            if (errors.Count > 0) return errors;

            await _carRepository.UpdateCar(carId, carEditedResult.Value!);

            return carEditedResult.Value!;

        }
    }
}
