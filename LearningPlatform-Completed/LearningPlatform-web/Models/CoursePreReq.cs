using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class CoursePreReq : Course
    {
        [Range(1.0, 10.0)]
        int RelativeImportance { get; set; }

        [Range(1.0, 10.0)]
        int MasteringLevel {get;set; }

        public CoursePreReq()
        {
        }

        public CoursePreReq(int _importance, int _masteringLevel)
        {
            this.RelativeImportance = _importance;
            this.MasteringLevel = _masteringLevel;
        }

    }
}
