using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [MaxLength(50)]
        public string DepartmentName { get; set; }

        [Display(Name = "Administrator")]
        public int? UserID { get; set; }

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}