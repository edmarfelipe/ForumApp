using Nancy;
using System.Dynamic;
using Nancy.Authentication.Forms;
using Nancy.Extensions;
using Forum.Commum.Interfaces.Repositories;

namespace Forum.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IAuthorRepository authorRepository)
        {
            Get("/login", args =>
            {
                dynamic model = new ExpandoObject();
                model.Errored = Request.Query.error.HasValue;

                return View["login", model];
            });

            Post("/login", args =>
            {
                var email = (string)Request.Form.Email;
                var password = (string)Request.Form.Password;

                var author = authorRepository.Authenticate(email, password);

                if (author == null)
                    return Context.GetRedirect("~/login?error=true&email=" + email);

                return this.LoginAndRedirect(author.NancyGuid);
            });

            Get("/logout", args =>
            {
                return this.LogoutAndRedirect("~/");
            });
        }
    }
}