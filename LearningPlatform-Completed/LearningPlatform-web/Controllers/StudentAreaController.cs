using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;
using LearningPlatform.ViewModels;

namespace LearningPlatform.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentAreaController : Controller
    {
        private PlatformDbContext db = new PlatformDbContext();
        //
        // GET: /InstructorArea/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /StudentArea/Courses/
        public ActionResult Courses()
        {
            User current = (User)Session["CurrentUser"];
            ViewBag.User = current.Email_ID;

            Student student = (from stu in db.Students
                                           where stu.Email_ID.Equals(current.Email_ID)
                                           select stu).FirstOrDefault();

            return View(student);
        }

        //
        // GET: /StudentArea/Profile
        public ActionResult Profile()
        {
            return View();
        }
   

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
