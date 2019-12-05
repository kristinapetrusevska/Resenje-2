using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Resenje_2.Startup))]
namespace Resenje_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
