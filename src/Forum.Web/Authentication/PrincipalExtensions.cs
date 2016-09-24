using System.Security.Claims;

namespace Forum.Web.Authentication
{
    public static class PrincipalExtensions
    {
        public static string GetAuthorId(this ClaimsPrincipal currentUser)
        {
            return currentUser.FindFirst(ForumClaimTypes.AuthorId).Value;
        }

        public static string GetName(this ClaimsPrincipal currentUser)
        {
            return currentUser.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
