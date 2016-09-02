using MongoDB.Bson;

namespace Forum.Infrastructure.Models
{
    public class Category
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string IconUrl { get; set; }
    }
}
