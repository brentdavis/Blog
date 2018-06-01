using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogBD.Startup))]
namespace BlogBD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
