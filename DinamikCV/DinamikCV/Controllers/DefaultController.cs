using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;


namespace DinamikCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DBCVEntities db = new DBCVEntities();
        public ActionResult Index()
        {
            var degerler = db.tblHakkimda.ToList();

            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler =db.tblDeneyimlerim.ToList();
            return PartialView(deneyimler);

        }
        public PartialViewResult SosyalMedya()
        {
            var smedya = db.tblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(smedya);

        }

        public PartialViewResult Egitim()
        {
            var egitimler= db.tblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim=db.tblYeteneklerim.ToList();
            return PartialView(yeteneklerim);
        }

        public PartialViewResult Projelerim()
        {
            var hobilerim = db.tblHobilerim.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = db.tblSertifikalarım.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(tbliletisim t)
        {
            t.Tarih =DateTime.Parse( DateTime.Now.ToShortDateString()); 
            db.tbliletisim.Add(t);
            db.SaveChanges();

            return PartialView();
        }
    }
}