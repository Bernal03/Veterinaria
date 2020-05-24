using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Controllers
{
    public class VeterinariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Veterinaries
        public ActionResult Index()
        {
            return View(db.Veterinaries.ToList());
        }

        // GET: Veterinaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinary veterinary = db.Veterinaries.Find(id);
            if (veterinary == null)
            {
                return HttpNotFound();
            }
            return View(veterinary);
        }

        // GET: Veterinaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinaries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Veterinary veterinary)
        {
            if (ModelState.IsValid)
            {
                db.Veterinaries.Add(veterinary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinary);
        }

        // GET: Veterinaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinary veterinary = db.Veterinaries.Find(id);
            if (veterinary == null)
            {
                return HttpNotFound();
            }
            return View(veterinary);
        }

        // POST: Veterinaries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Veterinary veterinary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinary);
        }

        // GET: Veterinaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinary veterinary = db.Veterinaries.Find(id);
            if (veterinary == null)
            {
                return HttpNotFound();
            }
            return View(veterinary);
        }

        // POST: Veterinaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinary veterinary = db.Veterinaries.Find(id);
            db.Veterinaries.Remove(veterinary);
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
