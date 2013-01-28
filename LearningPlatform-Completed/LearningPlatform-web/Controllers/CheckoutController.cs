using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;

namespace LearningPlatform.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        PlatformDbContext storeDB = new PlatformDbContext();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult DownloadProcess()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult DownloadProcess(FormCollection values)
        {
            var download = new Download();
            TryUpdateModel(download);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(download);
                }
                else
                {
                    download.Username = User.Identity.Name;
                    download.DownloadDate = DateTime.Now;

                    //Save Order
                    storeDB.Downloads.Add(download);
                    storeDB.SaveChanges();

                    //Process the order
                    var cart = DownloadCart.GetCart(this.HttpContext);
                    cart.CreateOrder(download);

                    return RedirectToAction("Complete",
                        new { id = download.DownloadId });
                }

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(download);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Downloads.Any(
                o => o.DownloadId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
