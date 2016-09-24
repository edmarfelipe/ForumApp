using Forum.Commum.Interfaces.Repositories;
using Forum.Commum.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Forum.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRespository, IAuthorRepository
    {
        private readonly IMongoCollection<Author> authorCollection;

        public AuthorRepository()
        {
            authorCollection = GetCollection<Author>();
        }

        public async void Insert(Author author)
        {
            await authorCollection.InsertOneAsync(author);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await authorCollection.Find(_ => true).ToListAsync();
        }

        public Author Authenticate(string email, string password)
        {
            return authorCollection.Find(x => x.Email == email 
                                        && x.Password == password).FirstOrDefault();
        }

        public Author GetByNancyGuid(Guid nancyGuid)
        {
            return authorCollection.Find(x => x.NancyGuid == nancyGuid).FirstOrDefault();
        }
    }
}
