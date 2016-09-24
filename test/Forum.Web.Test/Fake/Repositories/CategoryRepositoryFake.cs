using Forum.Commum.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Commum.Entities;

namespace Forum.Web.Test.Fake.Repositories
{
    public class CategoryRepositoryFake : ICategoryRepository
    {
        private readonly List<Category> categoryCollection;

        public CategoryRepositoryFake()
        {
            categoryCollection = new List<Category>();

            //categoryCollection.Add();
        }


        public Task<Category> GetBySlug(string categorySlug)
        {
           return Task.FromResult(categoryCollection.Where(x => x.Slug == categorySlug).SingleOrDefault());
        }

        public void Insert(Category category)
        {
            categoryCollection.Add(category);
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            return Task.FromResult(categoryCollection.AsEnumerable());
        }
    }
}
