using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Folkefinans.StockProductivity.Startup))]
namespace Folkefinans.StockProductivity
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
