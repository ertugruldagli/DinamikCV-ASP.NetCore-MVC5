using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;
using DinamikCV.Repositories;

namespace DinamikCV.Controllers
{
    public class CalismalarProjelerController : Controller
    {
        // GET: CalismalarProjeler
        GenericRepository<tblCalismalarProjeler> cRepo=new GenericRepository<tblCalismalarProjeler>();
        public ActionResult Index()
        {
            var calismalar = cRepo.TList();

            return View(calismalar);
        }
        [HttpGet]
        public ActionResult CalismalarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalismalarEkle(tblCalismalarProjeler p)
        {
            cRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult CalismalarSil(int id)
        {
            tblCalismalarProjeler t = cRepo.Find(x => x.ID == id);
            cRepo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CalismalarGuncelle(int id)
        {
            tblCalismalarProjeler t = cRepo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult CalismalarGuncelle(tblCalismalarProjeler p)
        {
            tblCalismalarProjeler t = cRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Baslik = p.Baslik;
            t.Konu = p.Konu;
            t.Aciklama = p.Aciklama;
         
            cRepo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}