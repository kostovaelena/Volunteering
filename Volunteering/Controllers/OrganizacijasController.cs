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
    public class OrganizacijasController : Controller
    {
        private VolunteeringContext db = new VolunteeringContext();

        // GET: Organizacijas
        public ActionResult Index()
        {
            return View(db.Organizacijas.ToList());
        }

      

        // GET: Organizacijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacija organizacija = db.Organizacijas.Find(id);
            if (organizacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImeOrg = organizacija.Ime;
            return View(organizacija);
        }

        // GET: Organizacijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizacijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Opis,Slika")] Organizacija organizacija)
        {
            if (ModelState.IsValid)
            {
                db.Organizacijas.Add(organizacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizacija);
        }

        // GET: Organizacijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacija organizacija = db.Organizacijas.Find(id);
            if (organizacija == null)
            {
                return HttpNotFound();
            }
            return View(organizacija);
        }

        // POST: Organizacijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Opis,Slika")] Organizacija organizacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizacija);
        }

        // GET: Organizacijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacija organizacija = db.Organizacijas.Find(id);
            if (organizacija == null)
            {
                return HttpNotFound();
            }
            return View(organizacija);
        }

        // POST: Organizacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizacija organizacija = db.Organizacijas.Find(id);
            db.Organizacijas.Remove(organizacija);
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
