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
    }
}