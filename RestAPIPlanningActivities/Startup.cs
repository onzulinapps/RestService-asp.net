using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestAPIPlanningActivities.Startup))]
namespace RestAPIPlanningActivities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
