using Nancy;

namespace ForumApp
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["Index"];
            };
        }
    }
}