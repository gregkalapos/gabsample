using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gab.WebFrontend.Startup))]
namespace Gab.WebFrontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
