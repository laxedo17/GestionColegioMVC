using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionColegioMVC.Startup))]
namespace GestionColegioMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
