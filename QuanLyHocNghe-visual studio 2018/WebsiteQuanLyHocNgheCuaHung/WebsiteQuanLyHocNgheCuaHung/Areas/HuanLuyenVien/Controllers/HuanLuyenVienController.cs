using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteQuanLyHocNgheCuaHung.Areas.HuanLuyenVien.Controllers
{
    [Authorize(Roles = "HuanLuyenVien")]
    public class HuanLuyenVienController : Controller
    {
        // GET: HuanLuyenVien/HuanLuyenVien
        public ActionResult Index()
        {
            return View();
        }
    }
}