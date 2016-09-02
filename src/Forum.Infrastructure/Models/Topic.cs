using MongoDB.Bson;

namespace Forum.Infrastructure.Models
{
    public class Topic
    {
        public ObjectId Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int Hearts { get; set; }

        public ObjectId AuthorId { get; set; }
    }
}
