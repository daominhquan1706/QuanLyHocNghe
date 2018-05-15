using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteQuanLyHocNgheCuaHung.Startup))]
namespace WebsiteQuanLyHocNgheCuaHung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
