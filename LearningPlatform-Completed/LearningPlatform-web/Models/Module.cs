using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        public String ModuleName { get; set;}

        public int CourseID { get; set; }

        public int ChapterID { get; set; }

    }
}