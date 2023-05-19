using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikCV.Models.Entity;

namespace DinamikCV.Controllers
{
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

        public PartialViewResult Egitim()
        {
            var egitimler= db.tblEgitimlerim.ToList();
            return PartialView(egitimler);
        }
    }
}