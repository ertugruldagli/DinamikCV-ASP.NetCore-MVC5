using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using DinamikCV.Models.Entity;

namespace DinamikCV.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
      
        DBCVEntities db=new DBCVEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(tblAdmin p)
        {
            var info = db.tblAdmin.FirstOrDefault(x=>x.KullaniciAdi==p.KullaniciAdi && x.Sifre==p.Sifre);
            if (info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.KullaniciAdi, false);
                Session["KullaniciAdi"]=info.KullaniciAdi.ToString();
                return RedirectToAction("Index","Deneyim");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}