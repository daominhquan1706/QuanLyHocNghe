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
    public class ChungChiSinhViensController : Controller
    {
        private Entities db = new Entities();

        // GET: ChungChiSinhViens
        public ActionResult Index()
        {
            var chungChiSinhViens = db.ChungChiSinhViens.Include(c => c.ChungChi).Include(c => c.SinhVien);
            return View(chungChiSinhViens.ToList());
        }

        // GET: ChungChiSinhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungChiSinhVien chungChiSinhVien = db.ChungChiSinhViens.Find(id);
            if (chungChiSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(chungChiSinhVien);
        }

        // GET: ChungChiSinhViens/Create
        public ActionResult Create()
        {
            ViewBag.MaChungChi = new SelectList(db.ChungChis, "MaChungChi", "TenChungChi");
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen");
            return View();
        }

        // POST: ChungChiSinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChungChiSinhVien,IDSinhVien,MaChungChi,NgayNhanChungChi")] ChungChiSinhVien chungChiSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.ChungChiSinhViens.Add(chungChiSinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChungChi = new SelectList(db.ChungChis, "MaChungChi", "TenChungChi", chungChiSinhVien.MaChungChi);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", chungChiSinhVien.IDSinhVien);
            return View(chungChiSinhVien);
        }

        // GET: ChungChiSinhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungChiSinhVien chungChiSinhVien = db.ChungChiSinhViens.Find(id);
            if (chungChiSinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChungChi = new SelectList(db.ChungChis, "MaChungChi", "TenChungChi", chungChiSinhVien.MaChungChi);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", chungChiSinhVien.IDSinhVien);
            return View(chungChiSinhVien);
        }

        // POST: ChungChiSinhViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChungChiSinhVien,IDSinhVien,MaChungChi,NgayNhanChungChi")] ChungChiSinhVien chungChiSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chungChiSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChungChi = new SelectList(db.ChungChis, "MaChungChi", "TenChungChi", chungChiSinhVien.MaChungChi);
            ViewBag.IDSinhVien = new SelectList(db.SinhViens, "IDSinhVien", "HoTen", chungChiSinhVien.IDSinhVien);
            return View(chungChiSinhVien);
        }

        // GET: ChungChiSinhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungChiSinhVien chungChiSinhVien = db.ChungChiSinhViens.Find(id);
            if (chungChiSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(chungChiSinhVien);
        }

        // POST: ChungChiSinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChungChiSinhVien chungChiSinhVien = db.ChungChiSinhViens.Find(id);
            db.ChungChiSinhViens.Remove(chungChiSinhVien);
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
