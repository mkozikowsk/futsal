using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Futsal_1.Context;
using Futsal_1.Models;

namespace Futsal_1.Controllers
{
    public class ArbitersController : Controller
    {
        private FutsalContext db = new FutsalContext();

        // GET: Arbiters
        public ActionResult Index()
        {
            return View(db.Arbiters.ToList());
        }

        // GET: Arbiters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbiter arbiter = db.Arbiters.Find(id);
            if (arbiter == null)
            {
                return HttpNotFound();
            }
            return View(arbiter);
        }

        // GET: Arbiters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arbiters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DateFrom,DateTo")] Arbiter arbiter)
        {
            if (ModelState.IsValid)
            {
                db.Arbiters.Add(arbiter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arbiter);
        }

        // GET: Arbiters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbiter arbiter = db.Arbiters.Find(id);
            if (arbiter == null)
            {
                return HttpNotFound();
            }
            return View(arbiter);
        }

        // POST: Arbiters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DateFrom,DateTo")] Arbiter arbiter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbiter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arbiter);
        }

        // GET: Arbiters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbiter arbiter = db.Arbiters.Find(id);
            if (arbiter == null)
            {
                return HttpNotFound();
            }
            return View(arbiter);
        }

        // POST: Arbiters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arbiter arbiter = db.Arbiters.Find(id);
            db.Arbiters.Remove(arbiter);
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
