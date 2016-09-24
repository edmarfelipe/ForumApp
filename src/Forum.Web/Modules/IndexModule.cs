using Forum.Commum.Interfaces.Repositories;
using Nancy;

namespace Forum.Web.Modules
{
    public class HomeModule : SecureModule
    {
        public HomeModule(ICategoryRepository categoryRepository, ITopicRepository topicRepository)
        {
            Get("/", async _ =>
            {            
                if (Request.Query.s.HasValue)
                {
                    var query = Request.Query.s.Value;

                    var categoriesResult = await topicRepository.Search(query);

                    return View["Search", categoriesResult];
                }

                var categories = await categoryRepository.GetAll();

                return View["Index", categories];
            });

        }
    }
}