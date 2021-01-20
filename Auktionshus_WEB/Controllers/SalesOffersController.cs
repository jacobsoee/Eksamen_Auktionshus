using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auktionshus_WEB.Models;
using Auktionshus_WEB.Controllers;

namespace Auktionshus_WEB.Controllers
{
    public class SalesOffersController : Controller
    {
        private AuktionDatabaseEntities db = new AuktionDatabaseEntities();

        // GET: SalesOffers
        public ActionResult Index()
        {
            var salesOffers = db.SalesOffers.Include(s => s.Account);
            return View(salesOffers.ToList());
        }

        // GET: SalesOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOffer salesOffer = db.SalesOffers.Find(id);
            if (salesOffer == null)
            {
                return HttpNotFound();
            }
            return View(salesOffer);
        }

        // GET: SalesOffers/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name");
            return View();
        }

        // POST: SalesOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MetalType,Amount,Deadline,AccountId")] SalesOffer salesOffer)
        {
            if (ModelState.IsValid)
            {
                salesOffer.AccountId = Int32.Parse(Session["UserID"].ToString());
                db.SalesOffers.Add(salesOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", salesOffer.AccountId);
            return View(salesOffer);
        }

        // GET: SalesOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOffer salesOffer = db.SalesOffers.Find(id);
            if (salesOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", salesOffer.AccountId);
            return View(salesOffer);
        }

        // POST: SalesOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MetalType,Amount,Deadline,AccountId")] SalesOffer salesOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", salesOffer.AccountId);
            return View(salesOffer);
        }

        // GET: SalesOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOffer salesOffer = db.SalesOffers.Find(id);
            if (salesOffer == null)
            {
                return HttpNotFound();
            }
            return View(salesOffer);
        }

        // POST: SalesOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOffer salesOffer = db.SalesOffers.Find(id);
            db.SalesOffers.Remove(salesOffer);
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
