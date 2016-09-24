using System.Security.Claims;

namespace Forum.Web.Authentication
{
    public class ForumIdentity : ClaimsIdentity
    {
        public ForumIdentity(string authorId, string name)
        {
            AuthorId = authorId;
            Name = name;

            base.AddClaim(new Claim(ForumClaimTypes.AuthorId, AuthorId));
            base.AddClaim(new Claim(NameClaimType, Name));
        }

        public string AuthorId { get; }

        public override string Name { get; }

        public override bool IsAuthenticated => !AuthorId.Equals("") && !Name.Equals("");
    }
}