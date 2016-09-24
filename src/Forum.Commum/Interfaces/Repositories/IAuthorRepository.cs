using Forum.Commum.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Commum.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        void Insert(Author author);

        Task<IEnumerable<Author>> GetAll();

        Author Authenticate(string email, string password);

        Author GetByNancyGuid(Guid nancyGuid);
    }
}
