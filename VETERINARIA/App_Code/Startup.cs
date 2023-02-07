using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VETERINARIA.Startup))]
namespace VETERINARIA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
