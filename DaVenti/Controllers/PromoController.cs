using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DaVenti.Models;

namespace DaVenti.Controllers
{
    [Authorize]
    public class PromoController : Controller
    {
        // GET: Promo
        public ActionResult Index()
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Promoes.ToList());
            }
        }

        // GET: Promo/Details/5
        public ActionResult Details(string id)
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Promoes.Where(x => x.id_promo == id).FirstOrDefault());
            }
        }

        // GET: Promo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promo/Create
        [HttpPost]
        public ActionResult Create(Promo promo)
        {
            try
            {
                // TODO: Add insert logic here
                using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
                {
                    dBEntities.Promoes.Add(promo);
                    dBEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Promo/Edit/5
        public ActionResult Edit(string id)
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Promoes.Where(x => x.id_promo == id).FirstOrDefault());
            }
        }

        // POST: Promo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Promo promo)
        {
            try
            {
                // TODO: Add update logic here
                using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
                {
                    dBEntities.Entry(promo).State = EntityState.Modified;
                    dBEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Promo/Delete/5
        public ActionResult Delete(string id)
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Promoes.Where(x => x.id_promo == id).FirstOrDefault());
            }
        }

        // POST: Promo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
                {
                    Promo promo = dBEntities.Promoes.Where(x => x.id_promo == id).FirstOrDefault();
                    dBEntities.Promoes.Remove(promo);
                    dBEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
