using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DaVenti.Models;
using System.Data.Entity;

namespace DaVenti.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (DaVentiDBEntities en = new DaVentiDBEntities())
            {
                return View(en.Categories.ToList());
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                using (DaVentiDBEntities en = new DaVentiDBEntities())
                {
                    en.Categories.Add(category);
                    en.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(string id)
        {
            using (DaVentiDBEntities en = new DaVentiDBEntities())
            {
                return View(en.Categories.Where(x => x.id_category == id).FirstOrDefault());
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Category category)
        {
            try
            {
                using (DaVentiDBEntities en = new DaVentiDBEntities())
                {
                    en.Entry(category).State = EntityState.Modified;
                    en.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Default/Delete/5
        public ActionResult Delete(string id)
        {
            using (DaVentiDBEntities en = new DaVentiDBEntities())
            {
                return View(en.Categories.Where(x => x.id_category == id).FirstOrDefault());
            }
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                using (DaVentiDBEntities en = new DaVentiDBEntities())
                {
                    Category category = en.Categories.Where(x => x.id_category == id).FirstOrDefault();
                    en.Categories.Remove(category);
                    en.SaveChanges();
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
