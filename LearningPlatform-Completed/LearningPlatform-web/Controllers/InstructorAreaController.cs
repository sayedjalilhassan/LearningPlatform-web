using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using LearningPlatform.Models;
using LearningPlatform.ViewModels;

namespace LearningPlatform.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class InstructorAreaController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();
        //
        // GET: /InstructorArea/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /InstructorArea/Details/5

        public ViewResult Details(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            return View(instructor);
        }

        //
        // GET: /InstructorArea/ManageCourses/9
        public ActionResult ManageCourses(Int32? id, Int32? courseID)
        {
            var viewModel = new InstructorIndexData();
            /* viewModel.Instructors = db.Instructors
                 .Include(i => i.Courses.Select(c => c.Department))
                 .OrderBy(i => i.InstructorName); */
            User current = (User)Session["CurrentUser"];
            ViewBag.User = current.Email_ID;

            viewModel.CurrentInstructor = (from inst in db.Instructors
                                           where inst.Email_ID.Equals(current.Email_ID)
                                           select inst).FirstOrDefault();


            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.CurrentInstructor.Courses;
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(x => x.CourseId == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        //
        // GET: /InstructorArea/Profile
        public ActionResult Profile()
        {
            return View();
        }

        //
        // GET: /InstructorArea/Create

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
                    getCurrentInstructor().Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes." +
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

        public Instructor getCurrentInstructor()
        {
            User current = (User)Session["CurrentUser"];
            ViewBag.User = current.Email_ID;

            return (from inst in db.Instructors
                    where inst.Email_ID.Equals(current.Email_ID)
                    select inst).FirstOrDefault();

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
