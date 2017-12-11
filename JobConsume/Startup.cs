using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobConsume.Startup))]
namespace JobConsume
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
