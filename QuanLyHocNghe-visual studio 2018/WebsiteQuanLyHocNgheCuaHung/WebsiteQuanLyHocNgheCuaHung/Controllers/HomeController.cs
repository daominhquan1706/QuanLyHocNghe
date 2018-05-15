using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyHocNgheCuaHung.Models;

namespace WebsiteQuanLyHocNgheCuaHung.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangKySinhVien(string Username)
        {
            var listuser = db.SinhViens.ToList();
            var id = db.AspNetUsers.Single(f => f.UserName.Equals(Username)).Id;
            if(listuser!=null)
            {
                foreach (var item in listuser)
                {
                    if(item.IDSinhVien==id)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult DangKySinhVien([Bind(Include = "IDSinhVien,MSSV,HoTen,DiaChi,NgonNguLapTrinh,NgaySinh,TrinhDoHocVan,DiemTOEFL,TinhTrangSinhVien")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sinhVien);
        }
        public ActionResult DangKyHuanLuyenVien(string Username)
        {
            var listuser = db.HuanLuyenViens.ToList();
            var id = db.AspNetUsers.Single(f => f.UserName.Equals(Username)).Id;
            if (listuser != null)
            {
                foreach (var item in listuser)
                {
                    if (item.IDHuanLuyenVien == id)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKyHuanLuyenVien([Bind(Include = "IDHuanLuyenVien,HoTen,DienThoai,BoPhan")] HuanLuyenVien huanLuyenVien)
        {
            if (ModelState.IsValid)
            {
                db.HuanLuyenViens.Add(huanLuyenVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(huanLuyenVien);
        }
    }
}