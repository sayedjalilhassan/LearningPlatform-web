using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningPlatform.Models;

namespace LearningPlatform.ViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public Instructor CurrentInstructor { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}