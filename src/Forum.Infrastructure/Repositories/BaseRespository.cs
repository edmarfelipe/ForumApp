using MongoDB.Driver;

namespace Forum.Infrastructure.Repositories
{
    public class BaseRespository<T> 
    {
        private const string _connectionString = "mongodb://localhost:27017";
        private const string _dataBaseName = "ForumApp";

        protected readonly IMongoCollection<T> Collection;

        public BaseRespository()
        {
            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_dataBaseName);

            Collection = database.GetCollection<T>(typeof(T).Name);
        }
    }
}