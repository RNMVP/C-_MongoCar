namespace MongoDBCars.Repositories
{
    public interface IBasicCrudRepo<T>
    {
        Task Create(T entity);
        Task<List<T>> Request();
        Task Update(string id, T entity);
        Task Delete(string id);
        Task<T> RequestById(string id);
    }
}
