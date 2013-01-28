using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.ViewModels
{
    public class CourseEnrollmentsGroup
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? EnrollmentDate { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }

        public int StudentCount { get; set; }
    }
}