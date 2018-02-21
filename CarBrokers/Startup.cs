using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarBrokers.Startup))]
namespace CarBrokers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
