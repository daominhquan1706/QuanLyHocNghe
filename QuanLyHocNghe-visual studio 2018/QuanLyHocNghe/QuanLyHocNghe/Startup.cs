using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyHocNghe.Startup))]
namespace QuanLyHocNghe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
