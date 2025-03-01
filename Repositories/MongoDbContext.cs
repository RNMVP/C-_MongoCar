using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBCars.Models;
using MongoDBCars.Models.config;
using MongoDBCars.Models.users;

namespace MongoDBCars.Repositories
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }
        public IMongoCollection<Car> Cars { get; }
        public IMongoCollection<Customer> Customers { get; set; }

        public MongoDbContext(IOptions<CarStoreDatabaseSettings> settings)
        {
            if (settings == null || settings.Value == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            Database = mongoClient.GetDatabase(settings.Value.DatabaseName);

            Cars = Database.GetCollection<Car>(settings.Value.CarsCollectionName);
            Customers = Database.GetCollection<Customer>(settings.Value.CustomersCollectionName);
        }
    }
}
