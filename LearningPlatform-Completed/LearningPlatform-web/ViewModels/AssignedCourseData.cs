using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform.ViewModels
{
    public class AssignedCourseData
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool Assigned { get; set; }
    }
}