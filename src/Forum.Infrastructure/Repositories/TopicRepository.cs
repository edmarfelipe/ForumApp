using Forum.Commum.Interfaces.Repositories;
using Forum.Commum.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using MongoDB.Bson;

namespace Forum.Infrastructure.Repositories
{
    public class TopicRepository : BaseRespository, ITopicRepository
    {
        private readonly IMongoCollection<Topic> topicCollection;
        private readonly IMongoCollection<Category> categoryCollection;

        public TopicRepository()
        {
            topicCollection = GetCollection<Topic>();
            categoryCollection = GetCollection<Category>();
        }

        public async void Insert(Topic topic)
        {
            await topicCollection.InsertOneAsync(topic);
        }

        public Topic GetById(string id)
        {
            return topicCollection.Find(x => x.Id == id).SingleOrDefault();
        }

        public Topic GetBySlug(string slug)
        {
            return topicCollection.Find(x => x.Slug == slug).SingleOrDefault();
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await topicCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Topic>> Search(string words)
        {

            var filter = new BsonDocument {
                {
                   "Title",
                    new BsonDocument {
                        { "$regex", words },
                        { "$options", "i" }
                    }
                }
            };

            var queryResult = topicCollection.FindSync(filter);

            return await queryResult.ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetAllByCategorySlug(string categorySlug)
        {
            var category = categoryCollection.Find(x => x.Slug == categorySlug.ToLower()).SingleOrDefault();

            var query = from t in topicCollection.AsQueryable()
                        where t.CategoryId == category.Id
                        select t;

            return await query.ToListAsync();
        }

        public async Task<int> SetHeart(string topicSlug, string authorId)
        {
            var topic = await topicCollection.Find(x => x.Slug == topicSlug.ToLower()).SingleAsync();

            var userHeart = topic.Hearts?.Where(x => x.Contains(authorId)).SingleOrDefault();

            if (userHeart == null)
            {
                topic.Hearts = new List<string>();
                topic.Hearts.Add(authorId);
            }
            else
            {
                topic.Hearts.Remove(authorId);
            }

            await topicCollection.UpdateOneAsync(
                      Builders<Topic>.Filter.Eq("Id", topic.Id),
                      Builders<Topic>.Update.Set("Hearts", topic.Hearts));

            return topic.Hearts.Count;
        }
    }
}
