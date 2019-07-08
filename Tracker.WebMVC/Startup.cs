using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tracker.WebMVC.Startup))]
namespace Tracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
