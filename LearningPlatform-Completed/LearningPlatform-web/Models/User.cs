using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class User
    {
        [Key]
        public int UserID {get;set;}

        public string UserName { get; set;}

        [Required]
        public int Type{get;set;}

        [Required]
        public string Email_ID { get; set; }

        [Required]
        public string Password{get;set;}
    
    }
}