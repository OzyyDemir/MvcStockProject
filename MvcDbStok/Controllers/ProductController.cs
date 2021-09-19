using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;

namespace MvcDbStok.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.URUNLER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> values = (from i in db.KATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(URUNLER urun)
        {
            var ct = db.KATEGORILER.Where(x => x.KATEGORIID == urun.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.KATEGORILER = ct;
            db.URUNLER.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var product = db.URUNLER.Find(id);
            db.URUNLER.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var product = db.URUNLER.Find(id);
            return View("UrunGetir", product);
        }
    }
}