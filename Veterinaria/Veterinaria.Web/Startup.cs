using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Veterinaria.Web.Startup))]
namespace Veterinaria.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
