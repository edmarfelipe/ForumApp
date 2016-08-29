using Nancy;

namespace ForumApp.Modules
{
    public class TopicModule : NancyModule
    {
        public TopicModule()
        {
            Get["/Topics"] = parameters => 
            {
                return View["Topics"];
            };

            Get["/Topic/New"] = parameters =>
            {
                return View["NewTopic"];
            };

            Get["/Topic/{id:int}"] = parameters =>
            {
                var a = parameters.value;

                return View["Topic"];
            };
        }
    }
}
