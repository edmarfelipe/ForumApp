using Forum.Commum.Interfaces.Repositories;
using Forum.Web.Modules;
using Forum.Web.Test.Fake;
using Forum.Web.Test.Fake.Repositories;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Testing;
using System;
using Xunit;

namespace Forum.Web.Test.Modules
{
    public class LoginModuleTest
    {
        [Fact]
        public async void Post_WrongEmailAndPassword_RedirectToLoginWithError()
        {
            // Given
            var browser = new Browser(cfg =>
            {
                cfg.Module<LoginModule>();
                cfg.Dependency<IAuthorRepository>(new AuthorRepositoryFake());
            });

            // When
            var response = await browser.Post("/Login", with =>
            {
                with.HttpRequest();
                with.FormValue("email", "user@mail.com");
                with.FormValue("password", "wrongpassword");
            });

            // Then
            response.ShouldHaveRedirectedTo("/login?error=true&email=user@mail.com");
        }

        [Fact]
        public async void Post_RightEmailAndPassword_RedirectToHome()
        {
            // Given
            var config = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login/",
                UserMapper = new UserFake()
            };

            var browser = new Browser(with =>
            {
                with.Module<LoginModule>();
                with.Dependency<IAuthorRepository>(new AuthorRepositoryFake());
                with.Dependency<IUserMapper>(new UserFake());
                with.ApplicationStartup(
                  (container, pipelines) => FormsAuthentication.Enable(pipelines, config)
                );
            });

            // When
            var response = await browser.Post("/Login", with =>
            {
                with.HttpRequest();
                with.FormValue("email", "user@mail.com");
                with.FormValue("password", "mypass");
            });

            // Then
            response.ShouldHaveRedirectedTo("/");
        }

        [Fact]
        public async void Get_Logout_LogOutUser()
        {
            // Given
            var config = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login/",
                UserMapper = new UserFake()
            };

            var browser = new Browser(with =>
            {
                with.Module<LoginModule>();
                with.Dependency<IAuthorRepository>(new AuthorRepositoryFake());
                with.Dependency<IUserMapper>(new UserFake());
                with.ApplicationStartup(
                    (container, pipelines) => FormsAuthentication.Enable(pipelines, config)
                );
            });

            // When
            var response = await browser.Get("/Logout", with =>
            {
                with.HttpRequest();
               // with.FormsAuth(Guid.Parse("5c3fadd2-053d-41aa-a65a-809ffacaa569"), config);
                //with.FormsAuth()"user@mail.com", "mypass2"
            });

            // Assert
            Assert.Equal(null, response.Context.CurrentUser);
        }

        [Fact]
        public async void Get_LoginPage_ResponseOK()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<LoginModule>();
                with.Dependency<IAuthorRepository>(new AuthorRepositoryFake());
            });

            // When
            var response = await browser.Get("/Login");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
