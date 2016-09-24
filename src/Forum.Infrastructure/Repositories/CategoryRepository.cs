using Forum.Commum.Interfaces.Repositories;
using Forum.Commum.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRespository, ICategoryRepository
    {
        private readonly IMongoCollection<Category> categoryCollection;

        public CategoryRepository()
        {
            categoryCollection = GetCollection<Category>();
        }

        public async void Insert(Category category)
        {
            await categoryCollection.InsertOneAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await categoryCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Category> GetBySlug(string categorySlug)
        {
            return await categoryCollection.Find(x => x.Slug == categorySlug.ToLower()).SingleAsync();
        }
    }
}
