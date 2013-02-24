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
    [Authorize(Roles = "Administrator")]
    public class PlatformManagerController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();

        //
        // GET: /PlatformManager/

        public ViewResult Index()
        {
            var chapters = db.Chapters.Include(c => c.Course).Include(c => c.Instructor);
            return View(chapters.ToList());
        }

        //
        // GET: /PlatformManager/Details/5

        public ViewResult Details(int id)
        {
            Chapter chapter = db.Chapters.Find(id);
            return View(chapter);
        }

        //
        // GET: /PlatformManager/Create

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.InstructorId = new SelectList(db.Instructors, "UserID", "InstructorName");
            return View();
        } 

        //
        // POST: /PlatformManager/Create

        [HttpPost]
        public ActionResult Create(Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Chapters.Add(chapter);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", chapter.CourseId);
            ViewBag.InstructorId = new SelectList(db.Instructors, "UserID", "InstructorName", chapter.InstructorId);
            return View(chapter);
        }
        
        //
        // GET: /PlatformManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Chapter chapter = db.Chapters.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", chapter.CourseId);
            ViewBag.InstructorId = new SelectList(db.Instructors, "UserID", "InstructorName", chapter.InstructorId);
            return View(chapter);
        }

        //
        // POST: /PlatformManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chapter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", chapter.CourseId);
            ViewBag.InstructorId = new SelectList(db.Instructors, "UserID", "InstructorName", chapter.InstructorId);
            return View(chapter);
        }

        //
        // GET: /PlatformManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Chapter chapter = db.Chapters.Find(id);
            return View(chapter);
        }

        //
        // POST: /PlatformManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Chapter chapter = db.Chapters.Find(id);
            db.Chapters.Remove(chapter);
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