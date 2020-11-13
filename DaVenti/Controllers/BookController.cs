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
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Books.ToList());
            }
            
        }

        // GET: Book/Details/5
        public ActionResult Details(string id)
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Books.Where(x => x.id_book == id).FirstOrDefault());
            }
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
                {
                    dBEntities.Books.Add(book);
                    dBEntities.SaveChanges();
                }
                // TODO: Add insert logic here
                ViewBag.Message = "Book added";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(string id)
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Books.Where(x => x.id_book == id).FirstOrDefault());
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Book book)
        {
            try
            {
                using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
                {
                    dBEntities.Entry(book).State = EntityState.Modified;
                    dBEntities.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(string id)
        {
            using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
            {
                return View(dBEntities.Books.Where(x => x.id_book == id).FirstOrDefault());
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DaVentiDBEntities dBEntities = new DaVentiDBEntities())
                {
                    Book book = dBEntities.Books.Where(x => x.id_book == id).FirstOrDefault();
                    dBEntities.Books.Remove(book);
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
