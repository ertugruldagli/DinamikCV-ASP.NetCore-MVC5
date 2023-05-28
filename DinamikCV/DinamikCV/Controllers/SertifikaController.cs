using DinamikCV.Models.Entity;
using DinamikCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository <tblSertifikalarım>  sRepo=new GenericRepository<tblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifikalar = sRepo.TList();
            return View(sertifikalar);
        }
    }
}