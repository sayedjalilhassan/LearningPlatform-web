using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

// Pre Req Modules for a given Module
namespace LearningPlatform.Models
{
    public class ModulePreReq:Module
    {
        [Range(1.0, 10.0)]
        public int RelativeImportance { get; set; }

        [Range(1.0, 10.0)]
        public int MasteringLevel {get;set; }

        public ModulePreReq()
        {
        }

        public ModulePreReq(int _importance,int _masteringLevel)
        {
            this.RelativeImportance = _importance;
            this.MasteringLevel = _masteringLevel;
        }
    }
}
