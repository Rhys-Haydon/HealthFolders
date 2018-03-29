using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models;

namespace TestApp2.Controllers
{
    public class LedgersController : Controller
    {
        private MoneyBinDataEntities1 db = new MoneyBinDataEntities1();

        // GET: Ledgers
        public ActionResult Index()
        {
            var ledgers = db.Ledgers.Include(l => l.User);
            return View(ledgers.ToList());
        }

        // GET: Ledgers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ledger ledger = db.Ledgers.Find(id);
            if (ledger == null)
            {
                return HttpNotFound();
            }
            return View(ledger);
        }

        // GET: Ledgers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName");
            ViewBag.FirstName = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Ledgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryID,UserID,LastName,FirstName,DatePaid,AmountPaid")] Ledger ledger)
        {
            if (ModelState.IsValid)
            {
                db.Ledgers.Add(ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", ledger.UserID);
            return View(ledger);
        }

        // GET: Ledgers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ledger ledger = db.Ledgers.Find(id);
            if (ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", ledger.UserID);
            return View(ledger);
        }

        // POST: Ledgers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryID,UserID,LastName,FirstName,DatePaid,AmountPaid")] Ledger ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", ledger.UserID);
            return View(ledger);
        }

        // GET: Ledgers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ledger ledger = db.Ledgers.Find(id);
            if (ledger == null)
            {
                return HttpNotFound();
            }
            return View(ledger);
        }

        // POST: Ledgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ledger ledger = db.Ledgers.Find(id);
            db.Ledgers.Remove(ledger);
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
