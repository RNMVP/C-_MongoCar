using MongoDBCars.Models.users;

namespace MongoDBCars.Repositories.CustomerRepo
{
    public class CustomerRepo(MongoDbContext context) : BasicCrudRepo<Customer>(context), ICustomerRepo
    {
    }
}
