using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LearningPlatform.Models
{
    [Bind(Exclude = "ChapterId")]
    public class Chapter
    {
        [ScaffoldColumn(false)]
        public int ChapterId { get; set; }

        [DisplayName("Course")]
        public int CourseId { get; set; }

        [DisplayName("Instructor")]
        public int InstructorId { get; set; }

        [Required(ErrorMessage = "A Chapter Title is required")]
        [StringLength(160)]
        public string ChapterTitle { get; set; }
        
        [DisplayName("Chapter Art URL")]
        [StringLength(1024)]
        public string ChapterArtUrl { get; set; }
        
        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual List<DownloadDetail> DownloadDetails { get; set; }
    }
}