using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyHocNgheCuaHung.Models;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;

namespace WebsiteQuanLyHocNgheCuaHung.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Entities db = new Entities();
        
        public ActionResult Index()
        {
            string userid = User.Identity.GetUserId();
            foreach (var item in db.SinhViens)
            {
                if(item.IDSinhVien == userid)
                {
                    return RedirectToAction("Index", "SinhVien",new { Area="SinhVien" });
                }
            }
            foreach (var item in db.HuanLuyenViens)
            {
                if (item.IDHuanLuyenVien == userid)
                {
                    return RedirectToAction("Index", "HuanLuyenVien", new { Area = "HuanLuyenVien" });
                }
            }
            if (User.Identity.GetUserName()=="admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult DangKySinhVien(string Username)
        {
            // chuyển user về đúng trang theo role , tránh lỗi
            string userid = User.Identity.GetUserId();
           
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
                return RedirectToAction("Index","SinhVien",new { area ="SinhVien" });
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
                return RedirectToAction("Index","HuanLuyenVien",new { Area ="HuanLuyenVien" });
            }
            return View(huanLuyenVien);
        }
        public ActionResult EditSinhVien(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewData["id"] = id;
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSinhVien([Bind(Include = "IDSinhVien,MSSV,HoTen,DiaChi,NgonNguLapTrinh,NgaySinh,TrinhDoHocVan,DiemTOEFL,TinhTrangSinhVien,DiemThiTracNghiem")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","SinhVien",new {Area="SinhVien" });
            }
            ViewBag.IDSinhVien = new SelectList(db.AspNetUsers, "Id", "Email", sinhVien.IDSinhVien);
            return View(sinhVien);
        }
        public ActionResult EditHuanLuyenVien(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HuanLuyenVien huanLuyenVien = db.HuanLuyenViens.Find(id);
            if (huanLuyenVien == null)
            {
                return HttpNotFound();
            }
            return View(huanLuyenVien);
        }

        // POST: HuanLuyenViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHuanLuyenVien([Bind(Include = "IDHuanLuyenVien,HoTen,DienThoai,BoPhan")] HuanLuyenVien huanLuyenVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huanLuyenVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHuanLuyenVien = new SelectList(db.AspNetUsers, "Id", "Email", huanLuyenVien.IDHuanLuyenVien);
            return View(huanLuyenVien);
        }
        // GET: ChungChiSinhViens/Create
        public ActionResult TraoChungChiChoSinhVien(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhvien = db.SinhViens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChungChi = new SelectList(db.ChungChis, "MaChungChi", "TenChungChi");
            ViewData["idsinhvien"] = sinhvien.IDSinhVien;
            return View();
        }

        // POST: ChungChiSinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TraoChungChiChoSinhVien([Bind(Include = "MaChungChiSinhVien,IDSinhVien,MaChungChi,NgayNhanChungChi")] ChungChiSinhVien chungChiSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.ChungChiSinhViens.Add(chungChiSinhVien);
                db.SaveChanges();
                return RedirectToAction("Index","HuanLuyenVien",new { Area=""});
            }

            ViewBag.MaChungChi = new SelectList(db.ChungChis, "MaChungChi", "TenChungChi", chungChiSinhVien.MaChungChi);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", chungChiSinhVien.IDSinhVien);
            return View(chungChiSinhVien);
        }
    }
}