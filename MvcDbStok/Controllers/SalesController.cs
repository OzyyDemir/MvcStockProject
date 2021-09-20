using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;

namespace MvcDbStok.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SATISLAR satis)
        {
            db.SATISLAR.Add(satis);
            db.SaveChanges();
            return View("Index");
        }
    }
}