using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Planesia.Startup))]
namespace Planesia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
