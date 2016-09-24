using Forum.Commum.Entities;
using Forum.Commum.Interfaces.Repositories;
using Forum.Web.Authentication;
using Forum.Web.Models;
using Nancy;
using Nancy.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using CommonMark;

namespace Forum.Web.Modules
{
    public class TopicModule : SecureModule
    {
        public TopicModule(ITopicRepository topicRepository, ICategoryRepository categoryRepository)
        {
            Get("/{slug}/", async args =>
            {
                var slug = args.slug.Value;
                var authorId = Context.CurrentUser.GetAuthorId();

                ViewBag.CategorySlug = slug;

                IEnumerable<Topic> topics = await topicRepository.GetAllByCategorySlug(slug);

                var top = new List<TopicsViewModel>();

                foreach (var item in topics)
                {
                    var userHeart = item.Hearts?.Where(x => x.Contains(authorId)).SingleOrDefault();

                    top.Add(new TopicsViewModel()
                    {
                        AuthorId = item.AuthorId,
                        Slug = item.Slug,
                        Title = item.Title,
                        Heart = userHeart == null ? 0 : 1,
                        Hearts = item.Hearts == null ? 0 : item.Hearts.Count
                    });
                }

                return View["Index", top];
            });

            Get("/{slug}/{slugTopic}", args =>
            {
                var topic = topicRepository.GetBySlug(args.slugTopic.Value);

                topic.Content = CommonMarkConverter.Convert(topic.Content);

                return View["Topic", topic];
            });

            Get("/{slug}/New", args =>
            {
                ViewBag.CategorySlug = args.slug.Value;

                return View["New"];
            });

            Post("/{slug}/{slugTopic}", args =>
            {
                return View["Topic"];
            });

            Post("/{slug}/Save", async args =>
            {
                var viewModelTopic = this.Bind<TopicViewModel>();

                var category = await categoryRepository.GetBySlug(args.slug.Value);

                var newTopic = new Topic(
                            viewModelTopic.Title,
                            viewModelTopic.Content,
                            category.Id,
                            Context.CurrentUser.GetAuthorId()
                        );

                topicRepository.Insert(newTopic);

                return Response.AsRedirect($"/{args.slug.Value}/{newTopic.Slug}");
            });

            Post("/{slug}/", async args =>
            {
                var slug = args.slug.Value;
                var authorId = Context.CurrentUser.GetAuthorId();

                return await topicRepository.SetHeart(slug, authorId);
            });
        }
    }
}
