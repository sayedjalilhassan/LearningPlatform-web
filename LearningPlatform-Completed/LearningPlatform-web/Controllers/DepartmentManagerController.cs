using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;
using System.Data.Entity.Infrastructure;

namespace LearningPlatform.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class DepartmentManagerController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();

        //
        // GET: /Department/

        public ViewResult Index()
        {
            var departments = db.Departments.Include(d => d.Administrator);
            return View(departments.ToList());
        }

        //
        // GET: /Department/Details/5

        public ViewResult Details(int id)
        {
            Department department = db.Departments.Find(id);
            return View(department);
        }

        //
        // GET: /Department/Create

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Instructors, "UserID", "InstructorName");
            return View();
        } 

        //
        // POST: /Department/Create

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.InstructorID = new SelectList(db.Instructors, "UserID", "InstructorName", department.UserID);
            return View(department);
        }
        
        //
        // GET: /Department/Edit/5
 
        public ActionResult Edit(int id)
        {
            Department department = db.Departments.Find(id);
            ViewBag.InstructorID = new SelectList(db.Instructors, "UserID", "InstructorName", department.UserID);
            return View(department);
        }

        //
        // POST: /Department/Edit/5

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(department).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseValues = (Department)entry.GetDatabaseValues().ToObject();
                var clientValues = (Department)entry.Entity;
                if (databaseValues.DepartmentName != clientValues.DepartmentName)
                    ModelState.AddModelError("Name", "Current value: "
                        + databaseValues.DepartmentName);
                if (databaseValues.UserID != clientValues.UserID)
                    ModelState.AddModelError("InstructorID", "Current value: "
                        + db.Instructors.Find(databaseValues.UserID).InstructorName);
                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                    + "was modified by another user after you got the original value. The "
                    + "edit operation was canceled and the current values in the database "
                    + "have been displayed. If you still want to edit this record, click "
                    + "the Save button again. Otherwise click the Back to List hyperlink.");
                department.Timestamp = databaseValues.Timestamp;
            }
            catch (DataException)
            {
                //Log the error (add a variable name after Exception)
                ModelState.AddModelError(string.Empty, "Unable to save changes."+
                    " Try again, and if the problem persists contact your system administrator.");
            }

            ViewBag.InstructorID = new SelectList(db.Instructors, "UserID", "InstructorName", department.UserID);
            return View(department);
        }

        //
        // GET: /Department/Delete/5

        public ActionResult Delete(int id, bool? concurrencyError)
        {
            if (concurrencyError.GetValueOrDefault())
            {
                ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                    + "was modified by another user after you got the original values. "
                    + "The delete operation was canceled and the current values in the "
                    + "database have been displayed. If you still want to delete this "
                    + "record, click the Delete button again. Otherwise "
                    + "click the Back to List hyperlink.";
            }

            Department department = db.Departments.Find(id);
            return View(department);
        }

        //
        // POST: /Department/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Department department)
        {
            try
            {
                db.Entry(department).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary { { "concurrencyError", true } });
            }
            catch (DataException)
            {
                //Log the error (add a variable name after Exception)
                ModelState.AddModelError(string.Empty, "Unable to save changes."+
                    " Try again, and if the problem persists contact your system administrator.");
                return View(department);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}