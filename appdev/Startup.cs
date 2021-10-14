using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(appdev.Startup))]
namespace appdev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
