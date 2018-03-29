using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBFirstTest.App_Data;

namespace DBFirstTest.Controllers
{
    public class TblEmployeesController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        // GET: TblEmployees
        public ActionResult Index()
        {
            return View(db.TblEmployees.ToList());
        }

        // GET: TblEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: TblEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,Salary")] TblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.TblEmployees.Add(tblEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmployee);
        }

        // GET: TblEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: TblEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,Salary")] TblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmployee);
        }

        // GET: TblEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: TblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            db.TblEmployees.Remove(tblEmployee);
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
