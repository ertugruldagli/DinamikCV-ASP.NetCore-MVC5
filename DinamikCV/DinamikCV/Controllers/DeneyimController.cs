using DinamikCV.Models.Entity;
using DinamikCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository dRepo =new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = dRepo.TList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(tblDeneyimlerim p)
        {
           dRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil (int id)
        {
            tblDeneyimlerim t = dRepo.Find(x=> x.ID==id);
            dRepo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            tblDeneyimlerim t = dRepo.Find(x=>x.ID==id);
            return View(t);

        }
        [HttpPost]
        public ActionResult DeneyimGetir(tblDeneyimlerim p)
        {
            tblDeneyimlerim t = dRepo.Find(x => x.ID == p.ID);
            t.ID= p.ID;
            t.Baslik= p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Tarih=p.Tarih;
            t.Aciklama=p.Aciklama;
            dRepo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}