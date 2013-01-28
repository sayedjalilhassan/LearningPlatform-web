using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;
using LearningPlatform.ViewModels;

namespace LearningPlatform.Controllers
{
    public class InstructorManagerController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();

        //
        // GET: /InstructorManager/

        public ActionResult Index(Int32? id, Int32? courseID)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = db.Instructors
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.InstructorName);
            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.Instructors.Where(i => i.InstructorID == id.Value).Single().Courses;
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(x => x.CourseId == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        //
        // GET: /InstructorManager/Details/5

        public ViewResult Details(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            return View(instructor);
        }

        //
        // GET: /InstructorManager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InstructorManager/Create

        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        //
        // GET: /InstructorManager/Edit/5

        public ActionResult Edit(int id)
        {
            Instructor instructor = db.Instructors
                .Include(i => i.Courses)
                .Where(i => i.InstructorID == id)
                .Single();
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        //
        // POST: /InstructorManager/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection, string[] selectedCourses)
        {
            var instructorToUpdate = db.Instructors
                .Include(i => i.Courses)
                .Where(i => i.InstructorID == id)
                .Single();
            if (TryUpdateModel(instructorToUpdate, "", null, new string[] { "Courses" }))
            {
                try
                {

                    UpdateInstructorCourses(selectedCourses, instructorToUpdate);

                    db.Entry(instructorToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    //Log the error (add a variable name after DataException)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedCourseData(instructorToUpdate);
            return View(instructorToUpdate);
        }



        // populate list of courses for an instructor
        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = db.Courses;
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseId));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Assigned = instructorCourses.Contains(course.CourseId)
                });
            }
            ViewBag.Courses = viewModel;
        }

        // update courses list after editing 
        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.Courses = new List<Course>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.Courses.Select(c => c.CourseId));
            foreach (var course in db.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseId.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseId))
                    {
                        instructorToUpdate.Courses.Add(course);
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseId))
                    {
                        instructorToUpdate.Courses.Remove(course);
                    }
                }
            }
        }

        //
        // GET: /InstructorManager/Delete/5

        public ActionResult Delete(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            return View(instructor);
        }

        //
        // POST: /InstructorManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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