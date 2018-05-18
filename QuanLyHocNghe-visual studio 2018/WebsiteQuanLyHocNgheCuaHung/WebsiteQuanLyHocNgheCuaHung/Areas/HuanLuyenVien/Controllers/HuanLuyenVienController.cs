using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyHocNgheCuaHung.Models;

namespace WebsiteQuanLyHocNgheCuaHung.Areas.HuanLuyenVien.Controllers
{
    [Authorize(Roles = "HuanLuyenVien")]
    public class HuanLuyenVienController : Controller
    {
        Entities db = new Entities();
        // GET: HuanLuyenVien/HuanLuyenVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemSinhVien()
        {
            return View();
        }
        public ActionResult ChonSinhVienChatBox(string nguoinhan)
        {
            if (nguoinhan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["nguoinhan"] = nguoinhan;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChonSinhVienChatBox([Bind(Include = "Id,UserID_Gui,TinNhan,ThoiGian,UserID_Nhan")] ChatBox chatBox)
        {
            if (ModelState.IsValid)
            {
                db.ChatBoxes.Add(chatBox);
                db.SaveChanges();
                return RedirectToAction("ChonSinhVienChatBox", "HuanLuyenVien", new { nguoinhan = db.AspNetUsers.Single(g => g.Id.Equals(chatBox.UserID_Nhan)).UserName });
            }
            return RedirectToAction("ChonSinhVienChatBox", "HuanLuyenVien", new { nguoinhan = db.AspNetUsers.Single(g => g.Id.Equals(chatBox.UserID_Nhan)).UserName });
        }
        public ActionResult ChiTietSinhVien(string id)
        {
            ViewData["id"] = id;
            return View();
        }
    }
}