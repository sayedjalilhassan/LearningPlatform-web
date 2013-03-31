using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace LearningPlatform.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        public String ModuleName { get; set;}

        public int CourseID { get; set; }

        public int ChapterID { get; set; }

        [Range(1.0,10.0)]
        public int DifficultyLevel { get; set; }

        public List<ModulePreReq> PreReqs {get;set; }

        public List<Module> connectedModules {get;set; }


    }
}