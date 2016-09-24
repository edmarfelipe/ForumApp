using Forum.Commum.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Commum.Interfaces.Repositories
{
    public interface ITopicRepository
    {
        void Insert(Topic topic);

        Task<IEnumerable<Topic>> GetAll();

        Task<IEnumerable<Topic>> Search(string words);

        Task<IEnumerable<Topic>> GetAllByCategorySlug(string categorySlug);

        Task<int> SetHeart(string topicSlug, string authorId);

        Topic GetById(string id);

        Topic GetBySlug(string slug);
    }
}
