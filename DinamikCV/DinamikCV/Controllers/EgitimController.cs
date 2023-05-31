using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;
using DinamikCV.Repositories;

namespace DinamikCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<tblEgitimlerim> eRepo = new GenericRepository<tblEgitimlerim>();
      
        public ActionResult Index()
        {
            var egitimlerim = eRepo.TList();
            return View(egitimlerim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(tblEgitimlerim p) 
        {
            if (!ModelState.IsValid)
            {
                return View ("EgitimEkle");
            }
            eRepo.TAdd(p);
            return RedirectToAction ("Index");  
        }
        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            tblEgitimlerim t = eRepo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult EgitimGuncelle(tblEgitimlerim p)
        {
            tblEgitimlerim t = eRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Baslik=p.Baslik;
            t.AltBaslik1=p.AltBaslik1;
            t.AltBaslik2=p.AltBaslik2;
            t.Tarih=t.Tarih;
            eRepo.TUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var delete = eRepo.Find(x => x.ID == id);
            eRepo.TRemove(delete);

            return RedirectToAction("Index");
        }
    }
}