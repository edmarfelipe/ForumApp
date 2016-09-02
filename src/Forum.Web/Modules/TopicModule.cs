using Forum.Infrastructure.Models;
using Forum.Infrastructure.Repositories;
using Nancy;
using Nancy.ModelBinding;
using System.Dynamic;

namespace ForumApp.Modules
{
    public class TopicModule : NancyModule
    {
        private readonly TopicRepository _topicRepository;

        public TopicModule()
        {
            _topicRepository = new TopicRepository();


            Get["/Topic/List"] = p =>
            {
                return View["List"];
            };

            Get["/Topic/{slug}/New"] = p =>
            {
                ViewBag.CategorySlug = p.slug.Value;

                return View["New"];
            };

            Get["/Topic/{slug}/"] = p =>
            {
                dynamic model = new ExpandoObject();
                model.Id = p.Value;

                return View["Index", model];
            };

            Post["/Topic/{id:int}/Save"] = p =>
            {
                var topic = this.Bind<Topic>();

                _topicRepository.Insert(topic);

                return View["New"];
            };
        }
    }
}
