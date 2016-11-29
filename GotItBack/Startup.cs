using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GotItBack.Startup))]
namespace GotItBack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
