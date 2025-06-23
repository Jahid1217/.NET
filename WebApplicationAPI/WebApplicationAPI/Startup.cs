using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplicationAPI.StartupOwin))]

namespace WebApplicationAPI
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
