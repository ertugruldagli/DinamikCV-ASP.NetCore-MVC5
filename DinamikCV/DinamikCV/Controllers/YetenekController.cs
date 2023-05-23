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
    }
}