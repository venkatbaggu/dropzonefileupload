using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropZoneFileUpload.Startup))]
namespace DropZoneFileUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
