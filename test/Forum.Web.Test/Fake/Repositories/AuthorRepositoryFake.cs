using Forum.Commum.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Commum.Entities;

namespace Forum.Web.Test.Fake.Repositories
{
    public class AuthorRepositoryFake : IAuthorRepository
    {
        private readonly List<Author> authorCollection;

        public AuthorRepositoryFake()
        {
            authorCollection = new List<Author>();

            authorCollection.Add(new Author()
            {
                Id = "11",
                Email = "user@mail.com",
                Name = "User",
                NancyGuid = Guid.Parse("5c3fadd2-053d-41aa-a65a-809ffacaa569"),
                Password = "mypass"
            });
        }

        public Author Authenticate(string email, string password)
        {
            return authorCollection.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
        }

        public Task<IEnumerable<Author>> GetAll()
        {
            return Task.FromResult(authorCollection.AsEnumerable());
        }

        public Author GetByNancyGuid(Guid nancyGuid)
        {
            return authorCollection.Where(x => x.NancyGuid == nancyGuid).SingleOrDefault();
        }

        public void Insert(Author author)
        {
            authorCollection.Add(author);
        }
    }
}
