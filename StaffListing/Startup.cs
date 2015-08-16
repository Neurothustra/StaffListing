using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Peirce.FacultySearch.Startup))]
namespace Web.Peirce.FacultySearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
