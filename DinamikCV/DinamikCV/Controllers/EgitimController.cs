using System;
using System.Collections.Generic;
using System.Linq;
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
            eRepo.TAdd(p);
            return RedirectToAction ("Index");  
        }
    }
}