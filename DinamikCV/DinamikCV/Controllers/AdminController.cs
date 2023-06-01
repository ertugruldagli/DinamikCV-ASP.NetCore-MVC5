using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;
using DinamikCV.Repositories;

namespace DinamikCV.Controllers
{
   
    public class AdminController : Controller
    {

        GenericRepository<tblAdmin> aRepo=new GenericRepository<tblAdmin>();
        // GET: Admin
       
        public ActionResult Index()
        {
            var veriler = aRepo.TList();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(tblAdmin p)
        {
            aRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            tblAdmin t = aRepo.Find(x => x.ID == id);
            aRepo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            tblAdmin t = aRepo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult AdminDuzenle(tblAdmin p)
        {
            tblAdmin t = aRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
           
            aRepo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}