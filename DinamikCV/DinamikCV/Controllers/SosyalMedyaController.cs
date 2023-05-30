using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;
using DinamikCV.Repositories;

namespace DinamikCV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<tblSosyalMedya> sRepo=new GenericRepository<tblSosyalMedya>();
        public ActionResult Index()
        {
            var sosyalmedya = sRepo.TList();
            return View (sosyalmedya);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblSosyalMedya p)
        {
            sRepo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGuncelle(int id)
        {
            var veriler = sRepo.Find(x=>x.ID==id);
            return View(veriler);
        }
        [HttpPost]
        public ActionResult SayfaGuncelle(tblSosyalMedya p)
        {
            var veriler = sRepo.Find(x => x.ID == p.ID);
            veriler.Durum = true;
            veriler.Ad=p.Ad;    
            veriler.Link=p.Link;    
            veriler.ikon=p.ikon;
            sRepo.TUpdate(veriler);
            return RedirectToAction("Index");
        }
        public ActionResult SayfaSil(int id)
        {
            var veriler = sRepo.Find(x => x.ID == id);
            veriler.Durum = false;
            sRepo.TUpdate(veriler);
            return RedirectToAction("Index");
            return View(veriler);
        }
    }
}