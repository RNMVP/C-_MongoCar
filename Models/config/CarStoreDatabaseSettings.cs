namespace MongoDBCars.Models.config
{
    public class CarStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CarsCollectionName { get; set; } = null!;
        public string CustomersCollectionName { get; set; } = null!;
        public string EmployeesCollectionName { get; set; } = null!;
    }
}
