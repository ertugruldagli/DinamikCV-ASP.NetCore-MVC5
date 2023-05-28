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
            return View(t);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(tblSertifikalarım p) 
        {
            tblSertifikalarım t = sRepo.Find(x=>x.ID==p.ID);
            p.ID= t.ID;
            p.Aciklama = t.Aciklama;    
            p.Tarih= t.Tarih;
            sRepo.TUpdate(p);

            return RedirectToAction ("Index");
        }
    }
}