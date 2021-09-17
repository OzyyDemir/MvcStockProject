using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;


namespace MvcDbStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.MUSTERILER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER musteri)
        {
            db.MUSTERILER.Add(musteri);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var customer = db.MUSTERILER.Find(id);
            db.MUSTERILER.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var customer = db.MUSTERILER.Find(id);
            return View("MusteriGetir", customer);
        }

        public ActionResult Guncelle(MUSTERILER c)
        {
            var customer = db.MUSTERILER.Find(c.MUSTERIID);
            customer.MUSTERIAD = c.MUSTERIAD;
            customer.MUSTERISOYAD = c.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}