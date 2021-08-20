using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Volunteering.Data;
using Volunteering.Models;

namespace Volunteering.Controllers
{
    public class PrijavasController : Controller
    {
        private VolunteeringContext db = new VolunteeringContext();
        
        // GET: Prijavas
        public ActionResult Index()
        {
           return View(db.Prijavas.ToList());
        }

        // GET: Prijavas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // GET: Prijavas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prijavas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Prezime,Email,Telefon")] Prijava prijava)
        {
            Organizacija org = new Organizacija();
            if (ModelState.IsValid)
            {
                db.Prijavas.Add(prijava);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
           
           
            return View(prijava);
        }

        // GET: Prijavas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Prijavas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Prezime,Email,Telefon")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prijava);
        }

        // GET: Prijavas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Prijavas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prijava prijava = db.Prijavas.Find(id);
            db.Prijavas.Remove(prijava);
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
