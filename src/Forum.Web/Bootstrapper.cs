namespace Forum.Web
{
    using Commum.Interfaces.Repositories;
    using Infrastructure.Mapper;
    using Infrastructure.Repositories;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.Bootstrapper;
    using Nancy.Cryptography;
    using Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        public CryptographyConfiguration _cryptographyConfiguration;

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var category = new CategoryMap();
            var author = new AuthorMap();
            var topic = new TopicMap();

            _cryptographyConfiguration = new CryptographyConfiguration(
                new AesEncryptionProvider(new PassphraseKeyGenerator("SuperSecretPass", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })),
                new DefaultHmacProvider(new PassphraseKeyGenerator("UberSuperSecure", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })));

            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Register<ITopicRepository, TopicRepository>();
            container.Register<ICategoryRepository, CategoryRepository>();
            container.Register<IAuthorRepository, AuthorRepository>();
        }

        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(requestContainer, pipelines, context);

            var config = new FormsAuthenticationConfiguration()
            {
                RedirectUrl = "~/login",
                UserMapper = requestContainer.Resolve<IUserMapper>(),
                CryptographyConfiguration = _cryptographyConfiguration
            };

            FormsAuthentication.Enable(pipelines, config);
        }
    }
}