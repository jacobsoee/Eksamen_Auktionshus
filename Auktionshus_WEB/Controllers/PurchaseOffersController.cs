using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auktionshus_WEB.Models;

namespace Auktionshus_WEB.Controllers
{
    public class PurchaseOffersController : Controller
    {
        private AuktionDatabaseEntities db = new AuktionDatabaseEntities();

        // GET: PurchaseOffers
        public ActionResult Index()
        {
            var purchaseOffers = db.PurchaseOffers.Include(p => p.Account).Include(p => p.SalesOffer);
            return View(purchaseOffers.ToList());
        }

        // GET: PurchaseOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOffer purchaseOffer = db.PurchaseOffers.Find(id);
            if (purchaseOffer == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOffer);
        }

        // GET: PurchaseOffers/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.SalesOfferId = new SelectList(db.SalesOffers, "Id", "Amount");
            return View();
        }

        // POST: PurchaseOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,AccountId,SalesOfferId")] PurchaseOffer purchaseOffer)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOffers.Add(purchaseOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", purchaseOffer.AccountId);
            ViewBag.SalesOfferId = new SelectList(db.SalesOffers, "Id", "Amount", purchaseOffer.SalesOfferId);
            return View(purchaseOffer);
        }

        // GET: PurchaseOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOffer purchaseOffer = db.PurchaseOffers.Find(id);
            if (purchaseOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", purchaseOffer.AccountId);
            ViewBag.SalesOfferId = new SelectList(db.SalesOffers, "Id", "Amount", purchaseOffer.SalesOfferId);
            return View(purchaseOffer);
        }

        // POST: PurchaseOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,AccountId,SalesOfferId")] PurchaseOffer purchaseOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", purchaseOffer.AccountId);
            ViewBag.SalesOfferId = new SelectList(db.SalesOffers, "Id", "Amount", purchaseOffer.SalesOfferId);
            return View(purchaseOffer);
        }

        // GET: PurchaseOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOffer purchaseOffer = db.PurchaseOffers.Find(id);
            if (purchaseOffer == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOffer);
        }

        // POST: PurchaseOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOffer purchaseOffer = db.PurchaseOffers.Find(id);
            db.PurchaseOffers.Remove(purchaseOffer);
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
