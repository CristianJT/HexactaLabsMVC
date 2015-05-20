using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HxLabsMVCApplication.Startup))]
namespace HxLabsMVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
