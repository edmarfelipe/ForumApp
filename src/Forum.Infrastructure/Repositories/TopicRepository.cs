using Forum.Infrastructure.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repositories
{
    public class TopicRepository : BaseRespository<Topic>
    {
        public async void Insert(Topic topic)
        {
            await Collection.InsertOneAsync(topic);
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}
