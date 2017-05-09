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
    public class MatchesController : Controller
    {
        private FutsalContext db = new FutsalContext();

        // GET: Matches
        public ActionResult Index()
        {
            var Matches = db.Matches.Include(t => t.AwayTeam).Include(t => t.HomeTeam);
           return View(Matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match testMatch = db.Matches.Find(id);
            if (testMatch == null)
            {
                return HttpNotFound();
            }
            return View(testMatch);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,HomeTeamId,AwayTeamId")] Match testMatch)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(testMatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Name", testMatch.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", testMatch.HomeTeamId);
            return View(testMatch);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match testMatch = db.Matches.Find(id);
            if (testMatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Name", testMatch.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", testMatch.HomeTeamId);
            return View(testMatch);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,HomeTeamId,AwayTeamId")] Match testMatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testMatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Name", testMatch.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", testMatch.HomeTeamId);
            return View(testMatch);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match testMatch = db.Matches.Find(id);
            if (testMatch == null)
            {
                return HttpNotFound();
            }
            return View(testMatch);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match testMatch = db.Matches.Find(id);
            db.Matches.Remove(testMatch);
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
