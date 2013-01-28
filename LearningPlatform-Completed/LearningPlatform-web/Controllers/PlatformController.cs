using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;

namespace LearningPlatform.Controllers
{
    public class PlatformController : Controller
    {
        PlatformDbContext storeDB = new PlatformDbContext();
        //
        // GET: /Platform/

        public ActionResult Index()
        {
            var courses = storeDB.Courses.ToList();
            return View(courses);
        }


        //  /Platform/ChapterDetails

        public ActionResult Details(int id)
        {
            var chapter = storeDB.Chapters.Find(id);
            return View(chapter);
        }


        //  /Platform/Browse
        public ActionResult Browse(string course)
        {
            // Retrieve Course and its Associated Chapter from database

            var courseModel = storeDB.Courses.Include("Chapters")
                .Single(g => g.CourseName == course);

            return View(courseModel);
        }

        [ChildActionOnly]
        public ActionResult CourseMenu()
        {
            var courses = storeDB.Courses.ToList();
            return PartialView(courses);
        }

    }
}
