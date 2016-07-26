using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoDParent.Startup))]
namespace PoDParent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
