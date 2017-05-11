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
    public class MatchEventsController : Controller
    {
        private FutsalContext db = new FutsalContext();

        // GET: MatchEvents
        public ActionResult Index()
        {
            var matchEvents = db.MatchEvents.Include(m => m.EventType).Include(m => m.Match).Include(m => m.Player);
            return View(matchEvents.ToList());
        }

        // GET: MatchEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchEvent matchEvent = db.MatchEvents.Find(id);
            if (matchEvent == null)
            {
                return HttpNotFound();
            }
            return View(matchEvent);
        }

        // GET: MatchEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name");
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Id");
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName");
            return View();
        }

        // POST: MatchEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,EventTime,EventTypeId,PlayerId,MatchId")] MatchEvent matchEvent)
        {
            if (ModelState.IsValid)
            {
                db.MatchEvents.Add(matchEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", matchEvent.EventTypeId);
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Id", matchEvent.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName", matchEvent.PlayerId);
            return View(matchEvent);
        }

        // GET: MatchEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchEvent matchEvent = db.MatchEvents.Find(id);
            if (matchEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", matchEvent.EventTypeId);
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Id", matchEvent.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName", matchEvent.PlayerId);
            return View(matchEvent);
        }

        // POST: MatchEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,EventTime,EventTypeId,PlayerId,MatchId")] MatchEvent matchEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Name", matchEvent.EventTypeId);
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Id", matchEvent.MatchId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FirstName", matchEvent.PlayerId);
            return View(matchEvent);
        }

        // GET: MatchEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchEvent matchEvent = db.MatchEvents.Find(id);
            if (matchEvent == null)
            {
                return HttpNotFound();
            }
            return View(matchEvent);
        }

        // POST: MatchEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchEvent matchEvent = db.MatchEvents.Find(id);
            db.MatchEvents.Remove(matchEvent);
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
