using Forum.Commum.Helpers;
using System.Collections.Generic;

namespace Forum.Commum.Entities
{
    public class Topic
    {
        public Topic(string title, string content, string categoryId, string authorId)
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
            AuthorId = authorId;
            Slug = SlugHelper.Create(Title);
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CategoryId { get; set; }

        public string Slug { get; private set; }

        public List<string> Hearts { get; set; }

        public string AuthorId { get; set; }
    }
}
