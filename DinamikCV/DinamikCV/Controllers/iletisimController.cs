﻿using DinamikCV.Models.Entity;
using DinamikCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikCV.Controllers
{
    public class iletisimController : Controller
    {
        // GET: Ilet
        GenericRepository<tbliletisim> iRepo = new GenericRepository<tbliletisim>();
        public ActionResult Index()
        {
            var contact = iRepo.TList();
            return View(contact);
        }
    }
}