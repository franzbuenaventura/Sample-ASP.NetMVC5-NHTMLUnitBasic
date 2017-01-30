using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHtmlUnit_SampleMVC5.Startup))]
namespace NHtmlUnit_SampleMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
