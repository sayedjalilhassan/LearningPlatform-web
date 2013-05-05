using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;

namespace LearningPlatform.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/

        public ActionResult Index()
        {
            return View();
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetItem(string id, string caller)
        {
            // Do stuff
            return View();
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult SaveItem(string p1, string p2, string p3)
        //{
        //    // Do stuff
        //    Console.WriteLine(p1,p2,p3);
        //    return View();
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveItem()
        {
            // Do stuff
            //Console.WriteLine(postData.GetValues(0)+"", postData.GetValues(1)+"");
            return View();
        }
    }
}
