using System.Web.Mvc;

namespace WebsiteQuanLyHocNgheCuaHung.Areas.HuanLuyenVien
{
    public class HuanLuyenVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HuanLuyenVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HuanLuyenVien_default",
                "HuanLuyenVien/{controller}/{action}/{id}",
                new {controller="HuanLuyenVien", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}