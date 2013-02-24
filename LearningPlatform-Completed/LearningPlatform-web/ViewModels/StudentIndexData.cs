using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningPlatform.Models;

namespace LearningPlatform.ViewModels
{
    public class StudentIndexData
    {
        public IEnumerable<Student> Students { get; set; }
        public Student CurrentStudent { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}