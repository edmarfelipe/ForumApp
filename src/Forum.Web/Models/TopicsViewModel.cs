namespace Forum.Web.Models
{
    public class TopicsViewModel
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string AuthorId { get; set; }

        public int Heart { get; set; }

        public int Hearts { get; set; }
    }
}