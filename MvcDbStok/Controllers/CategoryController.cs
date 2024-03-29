﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcDbStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int page=1)
        {
            //var values = db.KATEGORILER.ToList();
            var values = db.KATEGORILER.ToList().ToPagedList(page, 4);
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult YeniKategori(KATEGORILER kategori)
        {
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
            }
            db.KATEGORILER.Add(kategori);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var category = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var category = db.KATEGORILER.Find(id);
            return View("KategoriGetir",category);
        }

        public ActionResult Guncelle(KATEGORILER c)
        {
            var ct = db.KATEGORILER.Find(c.KATEGORIID);
            ct.KATEGORIAD = c.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}