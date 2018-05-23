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
    public class ChungChisController : Controller
    {
        private Entities db = new Entities();

        // GET: ChungChis
        public ActionResult Index()
        {
            return View(db.ChungChis.ToList());
        }

        // GET: ChungChis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungChi chungChi = db.ChungChis.Find(id);
            if (chungChi == null)
            {
                return HttpNotFound();
            }
            return View(chungChi);
        }

        // GET: ChungChis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChungChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChungChi,TenChungChi")] ChungChi chungChi)
        {
            if (ModelState.IsValid)
            {
                db.ChungChis.Add(chungChi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chungChi);
        }

        // GET: ChungChis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungChi chungChi = db.ChungChis.Find(id);
            if (chungChi == null)
            {
                return HttpNotFound();
            }
            return View(chungChi);
        }

        // POST: ChungChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChungChi,TenChungChi")] ChungChi chungChi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chungChi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chungChi);
        }

        // GET: ChungChis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungChi chungChi = db.ChungChis.Find(id);
            if (chungChi == null)
            {
                return HttpNotFound();
            }
            return View(chungChi);
        }

        // POST: ChungChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChungChi chungChi = db.ChungChis.Find(id);
            db.ChungChis.Remove(chungChi);
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
