using Forum.Commum.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Commum.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        void Insert(Category category);

        Task<IEnumerable<Category>> GetAll();

        Task<Category> GetBySlug(string categorySlug);
    }
}