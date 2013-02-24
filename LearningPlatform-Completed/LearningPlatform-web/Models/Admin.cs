using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class Admin:User
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Administrator name is required.")]
        [Display(Name = "Administrator Name")]
        public string AdminName { get; set; }
    }
}