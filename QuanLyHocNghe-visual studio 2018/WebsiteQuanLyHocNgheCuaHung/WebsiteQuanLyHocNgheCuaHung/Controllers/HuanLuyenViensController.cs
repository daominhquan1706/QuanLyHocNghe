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
    public class HuanLuyenViensController : Controller
    {
        private Entities db = new Entities();

        // GET: HuanLuyenViens
        public ActionResult Index()
        {
            var huanLuyenViens = db.HuanLuyenViens.Include(h => h.AspNetUser);
            return View(huanLuyenViens.ToList());
        }

        // GET: HuanLuyenViens/Details/5
        public ActionResult Details(string id)
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

        // GET: HuanLuyenViens/Create
        public ActionResult Create()
        {
            ViewBag.IDHuanLuyenVien = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: HuanLuyenViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHuanLuyenVien,HoTen,DienThoai,BoPhan")] HuanLuyenVien huanLuyenVien)
        {
            if (ModelState.IsValid)
            {
                db.HuanLuyenViens.Add(huanLuyenVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHuanLuyenVien = new SelectList(db.AspNetUsers, "Id", "Email", huanLuyenVien.IDHuanLuyenVien);
            return View(huanLuyenVien);
        }

        // GET: HuanLuyenViens/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.IDHuanLuyenVien = new SelectList(db.AspNetUsers, "Id", "Email", huanLuyenVien.IDHuanLuyenVien);
            return View(huanLuyenVien);
        }

        // POST: HuanLuyenViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHuanLuyenVien,HoTen,DienThoai,BoPhan")] HuanLuyenVien huanLuyenVien)
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

        // GET: HuanLuyenViens/Delete/5
        public ActionResult Delete(string id)
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

        // POST: HuanLuyenViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HuanLuyenVien huanLuyenVien = db.HuanLuyenViens.Find(id);
            db.HuanLuyenViens.Remove(huanLuyenVien);
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
