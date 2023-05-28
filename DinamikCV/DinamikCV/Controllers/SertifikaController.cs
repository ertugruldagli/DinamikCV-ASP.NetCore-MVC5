using DinamikCV.Models.Entity;
using DinamikCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository <tblSertifikalarım>  sRepo=new GenericRepository<tblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifikalar = sRepo.TList();
            return View(sertifikalar);
        }
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            tblSertifikalarım t = sRepo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(t);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(tblSertifikalarım p) 
        {
            tblSertifikalarım t = sRepo.Find(x => x.ID ==p.ID);

            t.ID= p.ID;
            t.Aciklama = p.Aciklama;
            t.Tarih= p.Tarih;
            sRepo.TUpdate(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(tblSertifikalarım p)
        {
            sRepo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id) 
        {
            var sertifika = sRepo.Find(x=>x.ID==id);
            sRepo.TRemove(sertifika);
            return RedirectToAction("Index");   
        }   
    }
}