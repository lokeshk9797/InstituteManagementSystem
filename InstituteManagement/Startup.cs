using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstituteManagement.Startup))]
namespace InstituteManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
