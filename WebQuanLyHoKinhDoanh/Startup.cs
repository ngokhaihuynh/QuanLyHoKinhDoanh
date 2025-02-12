using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebQuanLyHoKinhDoanh.Startup))]
namespace WebQuanLyHoKinhDoanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
