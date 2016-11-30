using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuickShipWeb.Startup))]
namespace QuickShipWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
