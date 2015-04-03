using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestAPIPlanningActivities.Startup))]
namespace RestAPIPlanningActivities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Configure the UserManager
            /*
            app.UseUserManagerFactory(new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = app.GetDataProtectionProvider(),
                Provider = new IdentityFactoryProvider<ApplicationUserManager>()
                {
                    OnCreate = ApplicationUserManager.Create
                }
            });
            */ 
        }
    }
}
