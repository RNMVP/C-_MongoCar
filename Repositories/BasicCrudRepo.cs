using MongoDB.Driver;

namespace MongoDBCars.Repositories
{
    public abstract class BasicCrudRepo<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        protected BasicCrudRepo(MongoDbContext context)
        {
            string collectionName = typeof(T).Name + "s";
            _collection = context.Database.GetCollection<T>(collectionName);
        }

        public async Task Create(T entity) 
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<List<T>> Request()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task Update(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<T> RequestById(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
