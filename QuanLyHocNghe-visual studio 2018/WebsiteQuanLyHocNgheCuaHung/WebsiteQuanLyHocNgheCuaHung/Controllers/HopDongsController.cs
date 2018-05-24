using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyHocNgheCuaHung.Models;

namespace WebsiteQuanLyHocNgheCuaHung.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HopDongsController : Controller
    {
        private Entities db = new Entities();

        // GET: HopDongs
        public ActionResult Index()
        {
            var hopDongs = db.HopDongs.Include(h => h.HuanLuyenVien).Include(h => h.SinhVien);
            return View(hopDongs.ToList());
        }

        // GET: HopDongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDongs.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // GET: HopDongs/Create
        public ActionResult Create()
        {
            ViewBag.IDHuanLuyenVien = new SelectList(db.HuanLuyenViens, "IDHuanLuyenVien", "HoTen");
            ViewBag.IDSinhVien = new SelectList(db.SinhViens.Where(r=>r.TinhTrangSinhVien.Equals("Chưa có hợp đồng")), "IDSinhVien", "HoTen");
            return View();
        }

        // POST: HopDongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSinhVien,IDHuanLuyenVien,NgayTaoHopDong,NgayKetThucHopDong")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                var dbsinhvien = db.SinhViens.Single(r => r.IDSinhVien.Equals(hopDong.IDSinhVien));
                dbsinhvien.TinhTrangSinhVien = "Đã Ký Hợp Đồng";
                db.Entry(dbsinhvien).State = EntityState.Modified;
                db.HopDongs.Add(hopDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHuanLuyenVien = new SelectList(db.HuanLuyenViens, "IDHuanLuyenVien", "HoTen", hopDong.IDHuanLuyenVien);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", hopDong.IDSinhVien);
            return View(hopDong);
        }

        // GET: HopDongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDongs.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHuanLuyenVien = new SelectList(db.HuanLuyenViens, "IDHuanLuyenVien", "HoTen", hopDong.IDHuanLuyenVien);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", hopDong.IDSinhVien);
            return View(hopDong);
        }

        // POST: HopDongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSinhVien,IDHuanLuyenVien,NgayTaoHopDong,NgayKetThucHopDong")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHuanLuyenVien = new SelectList(db.HuanLuyenViens, "IDHuanLuyenVien", "HoTen", hopDong.IDHuanLuyenVien);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", hopDong.IDSinhVien);
            return View(hopDong);
        }

        // GET: HopDongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDongs.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // POST: HopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HopDong hopDong = db.HopDongs.Find(id);
            db.HopDongs.Remove(hopDong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
