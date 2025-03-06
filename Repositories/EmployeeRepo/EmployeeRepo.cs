using MongoDBCars.Models.users;

namespace MongoDBCars.Repositories.EmployeeRepo
{
    public class EmployeeRepo(MongoDbContext context) : BasicCrudRepo<Employee>(context), IEmployeeRepo
    {
    }
}
