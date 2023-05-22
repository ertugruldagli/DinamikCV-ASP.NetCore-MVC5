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
    }
}