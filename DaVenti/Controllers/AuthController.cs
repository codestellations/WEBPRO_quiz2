using DaVenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaVenti.Controllers
{
    public class AuthController : Controller
    {
        // GET registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // POST registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Employee employee)
        {
            bool Status = false;
            string message = "";

            // model validation
            if (ModelState.IsValid)
            {
                #region email already exist
                var isExist = IsEmailExist(employee.email_emp);

                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(employee);
                }
                #endregion


                #region saving to database
                using(DaVentiDBEntities en = new DaVentiDBEntities())
                {
                    en.Employees.Add(employee);
                    en.SaveChanges();

                    message = "Registration successful. Welcome abroad!";
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(employee);
        }

        [NonAction]
        public bool IsEmailExist(string email)
        {
            using (DaVentiDBEntities en = new DaVentiDBEntities())
            {
                var check = en.Employees.Where(a => a.email_emp == email).FirstOrDefault();
                return check != null;
            }
        }
    }
}