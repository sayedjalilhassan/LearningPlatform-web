using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }
        
        [Required]
        public string CourseName { get; set; }
        
        public string CourseDescription { get; set; }
        
        public List<Chapter> Chapters { get; set; }
        
        public int Credits { get; set; }
        
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        
        public virtual Department Department { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}