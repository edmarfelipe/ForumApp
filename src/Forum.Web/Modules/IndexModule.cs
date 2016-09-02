using Forum.Infrastructure.Models;
using Forum.Infrastructure.Repositories;
using Nancy;

namespace ForumApp
{
    public class HomeModule : NancyModule
    {
		public HomeModule()
        {
            Get["/", true] = async (x, ct) =>
            {
                var categoryRepository = new CategoryRepository();

                var categories = await categoryRepository.GetAll();

                return View["Index", categories];
            };
        }
    }
}