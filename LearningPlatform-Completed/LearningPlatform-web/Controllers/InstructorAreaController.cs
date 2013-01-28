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
    public class InstructorAreaController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();
        //
        // GET: /InstructorArea/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageCourses(Int32? id, Int32? courseID)
        {
            var viewModel = new InstructorIndexData();
           /* viewModel.Instructors = db.Instructors
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.InstructorName); */

            viewModel.CurrentInstructor = db.Instructors.Find(id);

            //viewModel.CurrentInstructor.InstructorName = AccountController.loggedInUser.UserName;
             

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

        public ActionResult Profile()
        {
            return View();
        }


    }
}
