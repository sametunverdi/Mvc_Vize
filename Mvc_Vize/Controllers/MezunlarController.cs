using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Vize.Models;

namespace Mvc_Vize.Controllers
{
    public class MezunlarController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Mezunlar
        public ActionResult Index()
        {
            return View(db.Mezunlar.ToList());
        }

        // GET: Mezunlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // GET: Mezunlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mezunlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MezunId,MezunAd,MezunSoyad,MezunBolum")] Mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Mezunlar.Add(mezunlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mezunlar);
        }

        // GET: Mezunlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: Mezunlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MezunId,MezunAd,MezunSoyad,MezunBolum")] Mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mezunlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mezunlar);
        }

        // GET: Mezunlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: Mezunlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            db.Mezunlar.Remove(mezunlar);
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
