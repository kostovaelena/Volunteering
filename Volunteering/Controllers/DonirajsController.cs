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
    public class DonirajsController : Controller
    {
       
        private VolunteeringContext db = new VolunteeringContext();
       

        // GET: Donirajs
        public ActionResult Index()
        {
         /*  var model = new Doniraj();
          
            model.organizacii = db.Organizacijas.ToList();
           

           */
            return View(db.Donirajs.ToList());
            
        }

        public ActionResult Payment()
        {
            /*  Doniraj doniraj = new Doniraj();
              doniraj.Suma = suma;
              ViewBag.Suma = doniraj.Suma;*/
            ViewBag.Suma = this.Session["Suma"];
            return View();
        }

        

        // GET: Donirajs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doniraj doniraj = db.Donirajs.Find(id);
            if (doniraj == null)
            {
                return HttpNotFound();
            }
            return View(doniraj);
        }

        // GET: Donirajs/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Donirajs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Suma")] Doniraj doniraj)
        {
            if (ModelState.IsValid)
            {
                db.Donirajs.Add(doniraj);
                db.SaveChanges();

                this.Session["Suma"] = doniraj.Suma;
                return RedirectToAction("Payment");
            }
            

            return View(doniraj);
        }

        // GET: Donirajs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doniraj doniraj = db.Donirajs.Find(id);
            if (doniraj == null)
            {
                return HttpNotFound();
            }
            return View(doniraj);
        }

        // POST: Donirajs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Suma")] Doniraj doniraj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doniraj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doniraj);
        }

        // GET: Donirajs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doniraj doniraj = db.Donirajs.Find(id);
            if (doniraj == null)
            {
                return HttpNotFound();
            }
            return View(doniraj);
        }

        // POST: Donirajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doniraj doniraj = db.Donirajs.Find(id);
            db.Donirajs.Remove(doniraj);
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
