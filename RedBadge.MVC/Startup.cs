using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBadge.MVC.Startup))]
namespace RedBadge.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
