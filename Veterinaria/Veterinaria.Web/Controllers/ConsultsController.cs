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
    public class ConsultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consults
        public ActionResult Index()
        {
            return View(db.Consults.ToList());
        }

        // GET: Consults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consult consult = db.Consults.Find(id);
            if (consult == null)
            {
                return HttpNotFound();
            }
            return View(consult);
        }

        // GET: Consults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consults/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ConsultDate,Description,ConsultType")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                db.Consults.Add(consult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consult);
        }

        // GET: Consults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consult consult = db.Consults.Find(id);
            if (consult == null)
            {
                return HttpNotFound();
            }
            return View(consult);
        }

        // POST: Consults/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ConsultDate,Description,ConsultType")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consult);
        }

        // GET: Consults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consult consult = db.Consults.Find(id);
            if (consult == null)
            {
                return HttpNotFound();
            }
            return View(consult);
        }

        // POST: Consults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consult consult = db.Consults.Find(id);
            db.Consults.Remove(consult);
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
