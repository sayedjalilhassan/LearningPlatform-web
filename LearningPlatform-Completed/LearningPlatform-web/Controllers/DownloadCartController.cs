using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPlatform.Models;
using LearningPlatform.ViewModels;

namespace LearningPlatform.Controllers
{
    public class DownloadCartController : Controller
    {
        PlatformDbContext storeDB = new PlatformDbContext();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = DownloadCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new DownloadCartViewModel
            {
                CartItems = cart.GetCartItems(),
                //CartTotal = cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {

            // Retrieve the album from the database
            var addedChapter = storeDB.Chapters
                .Single(chapter => chapter.ChapterId == id);

            // Add it to the shopping cart
            var cart = DownloadCart.GetCart(this.HttpContext);

            cart.AddToCart(addedChapter);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /DownloadCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = DownloadCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string chapterName = storeDB.Carts
                .Single(item => item.RecordId == id).Chapter.ChapterTitle;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new DownloadCartRemoveViewModel
            {
                Message = Server.HtmlEncode(chapterName) +
                    " has been removed from your Download cart.",
               // CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = DownloadCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

    }
}
