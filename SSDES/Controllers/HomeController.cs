using SSDES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SSDES.Controllers
{
    public class HomeController : Controller
    {
        STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADMIN log)
        {
            var user = db.ADMINS.Where(x => x.USERNAME == log.USERNAME && x.PASSWORD == log.PASSWORD).Count();
            if (user > 0)
            {
                return RedirectToAction("Dashboard");
            }
            else if (log.USERNAME=="AdminManager" && log.PASSWORD=="n0TmYProject@#90")
            {
                return RedirectToAction("Admin_Dashbaord");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult Admin_Dashbaord()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult ADMIN()
        {
            using (SUBADMINEntities db = new SUBADMINEntities())
            {
                return View(db.ADMINS.ToList());
            }

        }

        // GET: Student/Details/5
        //play around with
        public ActionResult Admin_Details(int id)
        {
            using (SUBADMINEntities db = new SUBADMINEntities())
            {
                return View(db.ADMINS.Where(y => y.SBID == id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult New_Admin()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult New_Admin(ADMIN admin)
        {
            try
            {
                // TODO: Add insert logic here
                using (SUBADMINEntities db = new SUBADMINEntities())
                {
                    db.ADMINS.Add(admin);
                    db.SaveChanges();
                }
                return RedirectToAction("ADMIN");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete_Admin(int id)
        {
            using (SUBADMINEntities db = new SUBADMINEntities())
            {
                return View(db.ADMINS.Where(y => y.SBID == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete_Admin(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SUBADMINEntities db = new SUBADMINEntities())
                {
                    ADMIN admin = db.ADMINS.Where(y => y.SBID == id).FirstOrDefault();
                    db.ADMINS.Remove(admin);
                    db.SaveChanges();
                }
                return RedirectToAction("ADMIN");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit_Admin(int id)
        {
            using (SUBADMINEntities db = new SUBADMINEntities())
            {
                return View(db.ADMINS.Where(y => y.SBID == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit_Admin(int id, ADMIN admin)
        {
            try
            {
                using (SUBADMINEntities db = new SUBADMINEntities())
                {
                    db.Entry(admin).State = EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("ADMIN");
            }

            catch
            {
                return View();
            }

        }
    }
}