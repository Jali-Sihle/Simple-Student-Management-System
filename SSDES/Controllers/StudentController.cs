using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SSDES.Models;

namespace SSDES.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Students(string option)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                ViewBag.SortNameParameter = string.IsNullOrEmpty(option) ? "FIRST_NAME" : "";
                //ViewBag.SortLNameParameter = string.IsNullOrEmpty(option) ? "LAST_NAME" : "";

                var student = db.STUDENT_INFO.AsQueryable();
                //Sortings
                switch (option)
                {
                    case "FIRST_NAME":
                        student = student.OrderByDescending(x=>x.FIRST_NAME);
                        break;
                    default:
                        student = student.OrderBy(x=>x.FIRST_NAME);
                        break;
                }

                return View(student.ToList());

            }
               
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_INFO.Include(c=>c.STUDENT_TEST_RESULTS).Include(e=>e.STUDENT_PROJECT_RESULTS).Where(y => y.Stid == id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult New(STUDENT_INFO student)
        {
            try
            {
                // TODO: Add insert logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.STUDENT_INFO.Add(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Students");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_INFO.Where(y => y.Stid == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, STUDENT_INFO student)
        {
            try
            {
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Students");
            }

            catch
            {
                return View();
            }

        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {

            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_INFO.Where(y => y.Stid == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    STUDENT_INFO student = db.STUDENT_INFO.Where(y => y.Stid == id).FirstOrDefault();
                    var st = db.STUDENT_INFO.Where(y => y.Stid == id).Count();
                    STUDENT_TEST_RESULTS tests = db.STUDENT_TEST_RESULTS.Where(y => y.Stid == id).FirstOrDefault();
                    var ts = db.STUDENT_TEST_RESULTS.Where(y => y.Stid == id).Count();
                    STUDENT_PROJECT_RESULTS prj = db.STUDENT_PROJECT_RESULTS.Where(y => y.Stid == id).FirstOrDefault();
                    var pr = db.STUDENT_PROJECT_RESULTS.Where(y => y.Stid == id).Count();
                    EXAM_BOOKING eb = db.EXAM_BOOKING.Where(y => y.Stid == id).FirstOrDefault();
                    var exb = db.EXAM_BOOKING.Where(y => y.Stid == id).Count();
                    if (ts >0)
                    {
                        db.STUDENT_TEST_RESULTS.Remove(tests);
                    }
                    if (pr>0)
                    {
                        db.STUDENT_PROJECT_RESULTS.Remove(prj);
                    }
                    if (exb>0)
                    {
                        db.EXAM_BOOKING.Remove(eb);
                    }

                    db.STUDENT_INFO.Remove(student);
                    db.SaveChanges();

                }
                return RedirectToAction("Students");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string search) 
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_INFO.Where(y => y.FIRST_NAME==search).ToList());
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------------

        // GET: Student
        public ActionResult Students1(string option)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                ViewBag.SortNameParameter = string.IsNullOrEmpty(option) ? "TEST_MARK" : "";
                //ViewBag.SortLNameParameter = string.IsNullOrEmpty(option) ? "LAST_NAME" : "";

                var student = db.STUDENT_TEST_RESULTS.AsQueryable();

                switch (option)
                {
                    case "TEST_MARK":
                        student = student.OrderByDescending(x => x.TEST_MARK);
                        break;
                    default:
                        student = student.OrderBy(x => x.TEST_MARK);
                        break;
                }

                return View(student.ToList());

            }

        }

        // GET: Student/Details/5
        //play around with
        public ActionResult Details1(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                //var other = db.STUDENT_TEST_RESULTS.Include(c => c.STUDENT_INFO).Where(y => y.STR_id == id).FirstOrDefault();
                return View(db.STUDENT_TEST_RESULTS.Include(c => c.STUDENT_INFO).Where(y => y.STR_id == id).FirstOrDefault());
            }
        }


        // GET: Student/Create
        public ActionResult New1()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult New1(STUDENT_TEST_RESULTS student)
        {
            try
            {
                // TODO: Add insert logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.STUDENT_TEST_RESULTS.Add(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Students1");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit1(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_TEST_RESULTS.Where(y => y.STR_id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit1(int id, STUDENT_TEST_RESULTS student)
        {
            try
            {
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Students1");
            }

            catch
            {
                return View();
            }

        }

        // GET: Student/Delete/5
        public ActionResult Delete1(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_TEST_RESULTS.Include(c => c.STUDENT_INFO).Where(y => y.STR_id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete1(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    STUDENT_TEST_RESULTS student = db.STUDENT_TEST_RESULTS.Where(y => y.STR_id == id).FirstOrDefault();
                    db.STUDENT_TEST_RESULTS.Remove(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Students1");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search1(string search)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_TEST_RESULTS.Include(c=>c.STUDENT_INFO).Where(y => y.TEST_NAME == search).ToList());
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------
        // GET: Student
        public ActionResult Students2(string option)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                ViewBag.SortNameParameter = string.IsNullOrEmpty(option) ? "PROJECT_MARK" : "";
                //ViewBag.SortLNameParameter = string.IsNullOrEmpty(option) ? "LAST_NAME" : "";

                var student = db.STUDENT_PROJECT_RESULTS.AsQueryable();

                switch (option)
                {
                    case "PROJECT_MARK":
                        student = student.OrderByDescending(x => x.PROJECT_MARK);
                        break;
                    default:
                        student = student.OrderBy(x => x.PROJECT_MARK);
                        break;
                }

                return View(student.ToList());

            }

        }

        // GET: Student/Details/5
        //play around with
        public ActionResult Details2(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_PROJECT_RESULTS.Include(c => c.STUDENT_INFO).Where(y => y.SPR_id == id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult New2()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult New2(STUDENT_PROJECT_RESULTS student)
        {
            try
            {
                // TODO: Add insert logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.STUDENT_PROJECT_RESULTS.Add(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Students2");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit2(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_PROJECT_RESULTS.Where(y => y.SPR_id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit2(int id, STUDENT_PROJECT_RESULTS student)
        {
            try
            {
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Students2");
            }

            catch
            {
                return View();
            }

        }

        // GET: Student/Delete/5
        public ActionResult Delete2(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_PROJECT_RESULTS.Include(c => c.STUDENT_INFO).Where(y => y.SPR_id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete2(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    STUDENT_PROJECT_RESULTS student = db.STUDENT_PROJECT_RESULTS.Where(y => y.SPR_id == id).FirstOrDefault();
                    db.STUDENT_PROJECT_RESULTS.Remove(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Students2");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search2(string search)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.STUDENT_PROJECT_RESULTS.Include(c => c.STUDENT_INFO).Where(y => y.PROJECT_NAME == search).ToList());
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult Bookings(string option)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                ViewBag.SortNameParameter = string.IsNullOrEmpty(option) ? "EXAM_MODULE_NAME" : "";
                //ViewBag.SortLNameParameter = string.IsNullOrEmpty(option) ? "LAST_NAME" : "";

                var student = db.EXAM_BOOKING.AsQueryable();

                switch (option)
                {
                    case "EXAM_MODULE_NAME":
                        student = student.OrderByDescending(x => x.EXAM_MODULE_NAME);
                        break;
                    default:
                        student = student.OrderBy(x => x.EXAM_MODULE_NAME);
                        break;
                }

                return View(student.ToList());

            }

        }

        // GET: Student/Details/5
        //play around with
        public ActionResult ExamDetails(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.EXAM_BOOKING.Include(c => c.STUDENT_INFO).Where(y => y.Steb== id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult NewBooking()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult NewBooking(EXAM_BOOKING student)
        {
            try
            {
                // TODO: Add insert logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.EXAM_BOOKING.Add(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Bookings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult EditBooking(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.EXAM_BOOKING.Where(y => y.Steb == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult EditBooking(int id, EXAM_BOOKING student)
        {
            try
            {
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Bookings");
            }

            catch
            {
                return View();
            }

        }

        // GET: Student/Delete/5
        public ActionResult DeleteBooking(int id)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.EXAM_BOOKING.Include(c => c.STUDENT_INFO).Where(y => y.Steb == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult DeleteBooking(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
                {
                    EXAM_BOOKING student = db.EXAM_BOOKING.Where(y => y.Steb == id).FirstOrDefault();
                    db.EXAM_BOOKING.Remove(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Bookings");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchBooking(string search)
        {
            using (STUDENTWAREHOUSEEntities db = new STUDENTWAREHOUSEEntities())
            {
                return View(db.EXAM_BOOKING.Include(c => c.STUDENT_INFO).Where(y => y.EXAM_NUMBER == search).ToList());
            }
        }


    }
}
