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
    public class VolonterskiAngazmanController : Controller
    {
        private VolunteeringContext db = new VolunteeringContext();

        // GET: VolonterskiAngazmen
        public ActionResult Index(string search)
        {
            return View(db.VolonterskiAngazmen.Where( x => x.Naslov.Contains(search) || x.Mesto.Contains(search) || x.Datum.Contains(search) || x.Vreme.Contains(search) || x.Organizacija.Contains(search) || search == null).ToList());
           /* return View(db.VolonterskiAngazmen.ToList());*/
        }

        // GET: VolonterskiAngazmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolonterskiAngazman volonterskiAngazman = db.VolonterskiAngazmen.Find(id);
            if (volonterskiAngazman == null)
            {
                return HttpNotFound();
            }
            ViewBag.Naslov = volonterskiAngazman.Naslov;
            return View(volonterskiAngazman);
        }

        // GET: VolonterskiAngazmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VolonterskiAngazmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mesto,Datum,Vreme,Slika,Naslov,Organizacija")] VolonterskiAngazman volonterskiAngazman)
        {
            if (ModelState.IsValid)
            {
                db.VolonterskiAngazmen.Add(volonterskiAngazman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volonterskiAngazman);
        }

        // GET: VolonterskiAngazmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolonterskiAngazman volonterskiAngazman = db.VolonterskiAngazmen.Find(id);
            if (volonterskiAngazman == null)
            {
                return HttpNotFound();
            }
            return View(volonterskiAngazman);
        }

        // POST: VolonterskiAngazmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mesto,Datum,Vreme,Slika,Naslov,Organizacija")] VolonterskiAngazman volonterskiAngazman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volonterskiAngazman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volonterskiAngazman);
        }

        // GET: VolonterskiAngazmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolonterskiAngazman volonterskiAngazman = db.VolonterskiAngazmen.Find(id);
            if (volonterskiAngazman == null)
            {
                return HttpNotFound();
            }
            return View(volonterskiAngazman);
        }

        // POST: VolonterskiAngazmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VolonterskiAngazman volonterskiAngazman = db.VolonterskiAngazmen.Find(id);
            db.VolonterskiAngazmen.Remove(volonterskiAngazman);
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
