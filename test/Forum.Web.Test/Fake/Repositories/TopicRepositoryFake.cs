using Forum.Commum.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Commum.Entities;

namespace Forum.Web.Test.Fake.Repositories
{
    public class TopicRepositoryFake : ITopicRepository
    {
        private readonly List<Topic> topicCollection;

        public TopicRepositoryFake()
        {
            topicCollection = new List<Topic>();
        }

        public Task<IEnumerable<Topic>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetAllByCategorySlug(string categorySlug)
        {
            throw new NotImplementedException();
        }

        public Topic GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Topic GetBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public void Insert(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> Search(string words)
        {
            throw new NotImplementedException();
        }

        public Task<int> SetHeart(string topicSlug, string authorId)
        {
            throw new NotImplementedException();
        }
    }
}
