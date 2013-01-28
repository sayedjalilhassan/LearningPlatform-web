using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Models
{
    public class DownloadDetail
    {
        public int DownloadDetailId { get; set; }
        public int DownloadId { get; set; }
        public int ChapterId { get; set; }
        public int Quantity { get; set; }
        //public decimal UnitPrice { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual Download Download { get; set; }
    }
}
