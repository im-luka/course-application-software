using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aplikacija1.Startup))]
namespace Aplikacija1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
