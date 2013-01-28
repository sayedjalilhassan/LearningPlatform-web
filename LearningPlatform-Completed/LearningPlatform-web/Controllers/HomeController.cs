using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LearningPlatform.Models;
using LearningPlatform.ViewModels;

namespace LearningPlatform.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        PlatformDbContext db = new PlatformDbContext();

        public ActionResult Index()
        {
            // Get most popular albums
            var chapters = GetTopDownloadedChapters(5);

            return View(chapters);
        }

        private List<Chapter> GetTopDownloadedChapters(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return db.Chapters.OrderByDescending(a => a.DownloadDetails.Count()).Take(count).ToList();
        }

        public ActionResult About()
        {
            var data = from student in db.Enrollments
                       group student by student.Course.CourseName into courseGroup
                       select new CourseEnrollmentsGroup()
                       {
                           CourseName = courseGroup.Key,
                           StudentCount = courseGroup.Count()
                       };
            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}