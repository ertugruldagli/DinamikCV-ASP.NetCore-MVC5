using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;
using DinamikCV.Repositories;


namespace DinamikCV.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkımda
        GenericRepository<tblHakkimda> hRepo=new GenericRepository<tblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = hRepo.TList();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(tblHakkimda p)
        {
            var hakkimda = hRepo.Find(x=>x.ID==1);
            hakkimda.Ad=p.Ad;
            hakkimda.Soyad=p.Soyad;
            hakkimda.Adres=p.Adres;
            hakkimda.Telefon=p.Telefon;
            hakkimda.Mail=p.Mail;   
            hakkimda.Resim=p.Resim;
            hRepo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }
}