using System;

namespace Forum.Commum.Entities
{
    public class Author
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid NancyGuid { get; set; }
    }
}
