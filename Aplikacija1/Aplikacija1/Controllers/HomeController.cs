using Aplikacija1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string pretraga)
        {
            List<Seminar> nePopunjeni = (from np in db.Seminari
                                         where np.Popunjen == false
                                         select np).ToList();
            return View(db.Seminari.Where(x => x.Naziv.Contains(pretraga) || pretraga == null && x.Popunjen == false).ToList());
        }

        public ActionResult Predbiljezba()
        {
            ViewBag.SeminarID = new SelectList(db.Seminari.Where(x => x.Popunjen == false), "SeminarID", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Predbiljezba([Bind(Include = "PredbiljezbaID,Datum,Ime,Prezime,Adresa,Email,Telefon,SeminarID,Status")] Predbiljezba predbiljezba)
        {
            predbiljezba.Datum = DateTime.Now.ToString();

            if (ModelState.IsValid)
            {
                db.Predbiljezbe.Add(predbiljezba);
                db.SaveChanges();
                ViewBag.Poruka = "Predbilježba je uspješno obavljena!";
                return RedirectToAction("Index");
            }

            ViewBag.SeminarID = new SelectList(db.Seminari, "SeminarID", "Naziv", predbiljezba.SeminarID);

            return View(predbiljezba);
        }

        public ActionResult Pocetna()
        {
            return View();
        }
    }
}