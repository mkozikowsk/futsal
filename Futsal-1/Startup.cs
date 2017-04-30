using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Futsal_1.Startup))]
namespace Futsal_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
