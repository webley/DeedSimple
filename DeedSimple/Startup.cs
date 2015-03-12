using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeedSimple.Startup))]
namespace DeedSimple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
