using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSDES.Startup))]
namespace SSDES
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
