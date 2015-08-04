using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeleniumSample.Startup))]
namespace SeleniumSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
