using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningPlatform.Models;

namespace LearningPlatform.ViewModels
{
    public class DownloadCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}