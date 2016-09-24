using Nancy;
using Nancy.Security;

namespace Forum.Web.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
        {
            this.RequiresAuthentication();
        }
    }
}