using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class Instructor:User
    {
        //public int InstructorID { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Instructor name is required.")]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}