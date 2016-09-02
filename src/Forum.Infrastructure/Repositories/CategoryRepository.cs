using Forum.Infrastructure.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRespository<Category>
    {
        public async void Insert(Category category)
        {
            await Collection.InsertOneAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}
