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
            List<SelectListItem> values = (from i in db.KATEGORILER.ToList()
                                           select new SelectListItem {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View("UrunGetir", product);
        }

        public ActionResult Guncelle(URUNLER urun)
        {
            var p = db.URUNLER.Find(urun.URUNID);
            p.URUNAD = urun.URUNAD;
            p.MARKA = urun.MARKA;
            p.FIYAT = urun.FIYAT;
            p.STOK = urun.STOK;
            //p.URUNKATEGORI = product.URUNKATEGORI;
            var ct = db.KATEGORILER.Where(x => x.KATEGORIID == urun.KATEGORILER.KATEGORIID).FirstOrDefault();
            p.URUNKATEGORI = ct.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}