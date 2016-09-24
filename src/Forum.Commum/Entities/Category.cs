using Forum.Commum.Helpers;

namespace Forum.Commum.Entities
{
    public class Category
    {
        public Category(string name, string iconUrl)
        {
            Name = name;
            IconUrl = iconUrl;
            Slug = SlugHelper.Create(Name);
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; private set; }

        public string IconUrl { get; set; }
    }
}
