using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;
using DinamikCV.Repositories;

namespace DinamikCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek

        GenericRepository<tblYeteneklerim> yRepo = new GenericRepository<tblYeteneklerim>();


        public ActionResult Index()
        {
            var degerler = yRepo.TList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(tblYeteneklerim p)
        {
             yRepo.TAdd(p);
                
            return RedirectToAction("Index");   
        }

        public  ActionResult YetenekSil(int id)
        {
            tblYeteneklerim t = yRepo.Find(x => x.ID == id);
            yRepo.TRemove(t);
            return RedirectToAction("Index");
        }
    }
}