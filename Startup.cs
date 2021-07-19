using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QUEJATERD.Startup))]
namespace QUEJATERD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
