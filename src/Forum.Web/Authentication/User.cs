using System;
using System.Security.Claims;
using Nancy;
using Nancy.Authentication.Forms;
using Forum.Infrastructure.Repositories;

namespace Forum.Web.Authentication
{
    public class User : IUserMapper
    {
        public ClaimsPrincipal GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var authorRepository = new AuthorRepository();
            var author = authorRepository.GetByNancyGuid(identifier);

            return author == null ? null : new ClaimsPrincipal(new ForumIdentity(author.Id, author.Name));
        }
    }
}