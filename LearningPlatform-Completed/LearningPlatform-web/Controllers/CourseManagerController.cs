using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;

namespace LearningPlatform.Controllers
{
    public class CourseManagerController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();

        //
        // GET: /CourseManager/

        public ViewResult Index()
        {
            var courses = db.Courses.Include(c => c.Department);
            return View(courses.ToList());
        }

        //
        // GET: /CourseManager/Details/5

        public ViewResult Details(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // GET: /CourseManager/Create

        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }
        //
        // POST: /CourseManager/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes."+
                    " Try again, and if the problem persists, Contact your system administrator.");
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        //
        // Get: /CourseManager/Edit
        public ActionResult Edit(int id)
        {
            Course course = db.Courses.Find(id);
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        //
        // POST: /CourseManager/Edit
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes."+
                    " Try again, and if the problem persists, Contact your system administrator.");
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in db.Departments
                                   orderby d.DepartmentName
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "DepartmentName", selectedDepartment);
        }


        //
        // GET: /CourseManager/Delete/5

        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // POST: /CourseManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}