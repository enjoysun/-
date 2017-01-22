using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LuoXun.Startup))]
namespace LuoXun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
