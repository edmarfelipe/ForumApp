using Nancy.Authentication.Forms;
using System;
using Nancy;
using System.Security.Claims;
using Forum.Web.Test.Fake.Repositories;
using Forum.Web.Authentication;

namespace Forum.Web.Test.Fake
{
    public class UserFake : IUserMapper
    {
        public ClaimsPrincipal GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var authors = new AuthorRepositoryFake();

            var author = authors.GetByNancyGuid(identifier);

            return author == null ? null : new ClaimsPrincipal(new ForumIdentity(author.Id, author.Name));
        }
    }
}
