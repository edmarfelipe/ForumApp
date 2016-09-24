using MongoDB.Driver;

namespace Forum.Infrastructure.Repositories
{
    public class BaseRespository
    {
        private const string _connectionString = "mongodb://localhost:27017";
        private const string _dataBaseName = "ForumApp";

        private readonly IMongoDatabase dataBase;

        public BaseRespository()
        {
            var client = new MongoClient(_connectionString);
            dataBase = client.GetDatabase(_dataBaseName);
        }

        protected IMongoCollection<T> GetCollection<T>()
        {
            return dataBase.GetCollection<T>(typeof(T).Name);
        }
    }
}