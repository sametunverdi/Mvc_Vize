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
    public class idareController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: idare
        public ActionResult Index()
        {
            return View(db.idare.ToList());
        }

        // GET: idare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idare idare = db.idare.Find(id);
            if (idare == null)
            {
                return HttpNotFound();
            }
            return View(idare);
        }

        // GET: idare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: idare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdareId,IdariBirimAd,IdariAd")] idare idare)
        {
            if (ModelState.IsValid)
            {
                db.idare.Add(idare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idare);
        }

        // GET: idare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idare idare = db.idare.Find(id);
            if (idare == null)
            {
                return HttpNotFound();
            }
            return View(idare);
        }

        // POST: idare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdareId,IdariBirimAd,IdariAd")] idare idare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idare);
        }

        // GET: idare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idare idare = db.idare.Find(id);
            if (idare == null)
            {
                return HttpNotFound();
            }
            return View(idare);
        }

        // POST: idare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            idare idare = db.idare.Find(id);
            db.idare.Remove(idare);
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
