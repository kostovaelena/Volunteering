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
    public class KategorijasController : Controller
    {
        private VolunteeringContext db = new VolunteeringContext();

        // GET: Kategorijas
        public ActionResult Index()
        {
            return View(db.Kategorijas.ToList());
/*            return View(db.Kategorijas.Where(x => x.Ime.Contains(search) || search == null).ToList());
*/
        }

        // GET: Kategorijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorija kategorija = db.Kategorijas.Find(id);
            if (kategorija == null)
            {
                return HttpNotFound();
            }
            return View(kategorija);
        }


        public ActionResult Ekologija()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult Biznis()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult Humanost()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult Kultura()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult Aktivizam()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult Tehnologija()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult ZashtitaNaZivotnite()
        {
            return View(db.Kategorijas.ToList());
        }
        public ActionResult Zdravstvo()
        {
            return View(db.Kategorijas.ToList());
        }






        // GET: Kategorijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime")] Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                db.Kategorijas.Add(kategorija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorija);
        }

        // GET: Kategorijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorija kategorija = db.Kategorijas.Find(id);
            if (kategorija == null)
            {
                return HttpNotFound();
            }
            return View(kategorija);
        }

        // POST: Kategorijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime")] Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorija);
        }

        // GET: Kategorijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorija kategorija = db.Kategorijas.Find(id);
            if (kategorija == null)
            {
                return HttpNotFound();
            }
            return View(kategorija);
        }

        // POST: Kategorijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategorija kategorija = db.Kategorijas.Find(id);
            db.Kategorijas.Remove(kategorija);
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
