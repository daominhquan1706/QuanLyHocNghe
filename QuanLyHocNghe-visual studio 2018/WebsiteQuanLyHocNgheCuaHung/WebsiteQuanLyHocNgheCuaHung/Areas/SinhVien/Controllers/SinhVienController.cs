using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebsiteQuanLyHocNgheCuaHung.Models;


namespace WebsiteQuanLyHocNgheCuaHung.Areas.SinhVien.Controllers
{

    [Authorize(Roles = "SinhVien")]
    public class SinhVienController : Controller
    {
        private Entities db = new Entities();
        // GET: SinhVien/SinhVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KiemTraTrucTuyenCSharp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KiemTraTrucTuyenCSharp(string Cau1, string Cau2, string Cau3, string Cau4, string Cau5, string Cau6, string Cau7, string Cau8, string Cau9,string Cau10)
        {
            if (ModelState.IsValid)
            {
                List<string> DapAn = new List<string>();
                DapAn.Add(Cau1);
                DapAn.Add(Cau2);
                DapAn.Add(Cau3);
                DapAn.Add(Cau4);
                DapAn.Add(Cau5);
                DapAn.Add(Cau6);
                DapAn.Add(Cau7);
                DapAn.Add(Cau8);
                DapAn.Add(Cau9);
                DapAn.Add(Cau10);
                int SoCauDung = 0;
                int SoCauSai = 0;
                foreach (var item in DapAn)
                {
                    if(item=="dung")
                    {
                        SoCauDung++;
                    }
                    if (item == "sai")
                    {
                        SoCauSai++;
                    }
                }
                string id = User.Identity.GetUserId();
                var dataSinhVien = db.SinhViens.Single(y => y.IDSinhVien.Equals(id));
                dataSinhVien.DiemThiTracNghiem = SoCauDung;
                db.Entry(dataSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult KiemTraTrucTuyenJavaScript()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KiemTraTrucTuyenJavaScript(string Cau1, string Cau2, string Cau3, string Cau4, string Cau5, string Cau6, string Cau7, string Cau8, string Cau9, string Cau10)
        {
            if (ModelState.IsValid)
            {
                List<string> DapAn = new List<string>();
                DapAn.Add(Cau1);
                DapAn.Add(Cau2);
                DapAn.Add(Cau3);
                DapAn.Add(Cau4);
                DapAn.Add(Cau5);
                DapAn.Add(Cau6);
                DapAn.Add(Cau7);
                DapAn.Add(Cau8);
                DapAn.Add(Cau9);
                DapAn.Add(Cau10);
                int SoCauDung = 0;
                int SoCauSai = 0;
                foreach (var item in DapAn)
                {
                    if (item == "dung")
                    {
                        SoCauDung++;
                    }
                    if (item == "sai")
                    {
                        SoCauSai++;
                    }
                }
                string id = User.Identity.GetUserId();
                var dataSinhVien = db.SinhViens.Single(y => y.IDSinhVien.Equals(id));
                dataSinhVien.DiemThiTracNghiem = SoCauDung;
                db.Entry(dataSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChatVoiHLV([Bind(Include = "Id,UserID_Gui,TinNhan,ThoiGian,UserID_Nhan")] ChatBox chatBox)
        {
            if (ModelState.IsValid)
            {
                db.ChatBoxes.Add(chatBox);
                db.SaveChanges();
                return RedirectToAction("Index", "SinhVien");
            }
            return RedirectToAction("Index", "SinhVien");
        }

    }
}