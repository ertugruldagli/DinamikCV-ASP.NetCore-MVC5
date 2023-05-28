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
            var t = sRepo.Find(x=>x.ID==id);
            return View(t);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(tblSertifikalarım p) 
        {
            var t = sRepo.Find(x => x.ID ==p.ID);

            t.ID= p.ID;
            t.Aciklama = p.Aciklama;
            t.Tarih= p.Tarih;
            sRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}