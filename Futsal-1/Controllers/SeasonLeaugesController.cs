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
    public class SeasonLeaugesController : Controller
    {
        private FutsalContext db = new FutsalContext();

        // GET: SeasonLeauges
        public ActionResult Index()
        {
            var seasonLeauges = db.SeasonLeauges.Include(s => s.Season);
            return View(seasonLeauges.ToList());
        }

        // GET: SeasonLeauges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonLeague seasonLeauge = db.SeasonLeauges.Find(id);
            if (seasonLeauge == null)
            {
                return HttpNotFound();
            }
            return View(seasonLeauge);
        }

        // GET: SeasonLeauges/Create
        public ActionResult Create()
        {
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Id");
            return View();
        }

        // POST: SeasonLeauges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,SeasonId,TeamId")] SeasonLeague seasonLeauge)
        {
            if (ModelState.IsValid)
            {
                db.SeasonLeauges.Add(seasonLeauge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Id", seasonLeauge.SeasonId);
            return View(seasonLeauge);
        }

        // GET: SeasonLeauges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonLeague seasonLeauge = db.SeasonLeauges.Find(id);
            if (seasonLeauge == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Id", seasonLeauge.SeasonId);
            return View(seasonLeauge);
        }

        // POST: SeasonLeauges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,SeasonId,TeamId")] SeasonLeague seasonLeauge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasonLeauge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Id", seasonLeauge.SeasonId);
            return View(seasonLeauge);
        }

        // GET: SeasonLeauges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonLeague seasonLeauge = db.SeasonLeauges.Find(id);
            if (seasonLeauge == null)
            {
                return HttpNotFound();
            }
            return View(seasonLeauge);
        }

        // POST: SeasonLeauges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeasonLeague seasonLeauge = db.SeasonLeauges.Find(id);
            db.SeasonLeauges.Remove(seasonLeauge);
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
