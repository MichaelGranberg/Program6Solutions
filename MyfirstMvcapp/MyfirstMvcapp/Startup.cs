using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyfirstMvcapp.Startup))]
namespace MyfirstMvcapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
