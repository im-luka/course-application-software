using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplikacija1.Models;

namespace Aplikacija1.Controllers
{
    public class PredbiljezbeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Predbiljezbe
        public ActionResult Index(string pretraga)
        {
            List<Predbiljezba> nePopunjeni = (from np in db.Predbiljezbe
                                         where np.Seminar.Popunjen == false
                                         select np).ToList();
            if (Session["Registriran"] == null)
            {
                return RedirectToAction("Prijava", "Zaposlenici");
            }
            return View(db.Predbiljezbe.Where(x => x.Seminar.Naziv.Contains(pretraga) || pretraga == null).ToList());
        }

        // GET: Predbiljezbe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        // GET: Predbiljezbe/Create
        public ActionResult Create()
        {
            ViewBag.SeminarID = new SelectList(db.Seminari, "SeminarID", "Naziv");
            return View();
        }

        // POST: Predbiljezbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PredbiljezbaID,Datum,Ime,Prezime,Adresa,Email,Telefon,SeminarID,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Predbiljezbe.Add(predbiljezba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeminarID = new SelectList(db.Seminari, "SeminarID", "Naziv", predbiljezba.SeminarID);
            return View(predbiljezba);
        }

        // GET: Predbiljezbe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeminarID = new SelectList(db.Seminari, "SeminarID", "Naziv", predbiljezba.SeminarID);
            return View(predbiljezba);
        }

        // POST: Predbiljezbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PredbiljezbaID,Datum,Ime,Prezime,Adresa,Email,Telefon,SeminarID,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predbiljezba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeminarID = new SelectList(db.Seminari, "SeminarID", "Naziv", predbiljezba.SeminarID);
            return View(predbiljezba);
        }

        // GET: Predbiljezbe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        // POST: Predbiljezbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            db.Predbiljezbe.Remove(predbiljezba);
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
