using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningPlatform.Models.Recommender
{

    public class Recommender
    {
        private Module inputModule { get; set; }
        private Course inputCourse { get; set; }

        public Recommender()
        {
        }

        public Recommender(Course _inputCourse, Module _inputModule)
        {
            this.inputCourse = _inputCourse;
            this.inputModule = _inputModule;
        }

        public Course RecommendeCourse()
        {
            List<CoursePreReq> pre_reqs = this.inputCourse.;
            Double _summation = 0, _summationImportance = 0, _expectedValue = 0, highestValue_ = 0;
            Module result = new Module();
            foreach (Module c in this.inputModule.connectedModules)
            {
                foreach (ModulePreReq p in pre_reqs)
                {
                    _summation += p.MasteringLevel * p.RelativeImportance;
                    _summationImportance += p.RelativeImportance;
                }

                _summation *= c.DifficultyLevel;
                _expectedValue = _summation / _summationImportance;
                if (_expectedValue > highestValue_)
                {
                    result = c;
                    //highestValue_ = _expectedValue;
                }
            }



            return result;
        }
        /*
         * Calculate Expected value for Related Modules to recently Completed Module
         * and return the Module with Highest expected Value
         * */
        public Module RecommendModule()
        {
            List<ModulePreReq> pre_reqs = this.inputModule.PreReqs;
            Double _summation = 0, _summationImportance = 0, _expectedValue = 0, highestValue_ = 0;
            Module result = new Module();
            foreach (Module c in this.inputModule.connectedModules)
            {
                foreach (ModulePreReq p in pre_reqs)
                {
                    _summation += p.MasteringLevel * p.RelativeImportance;
                    _summationImportance += p.RelativeImportance;
                }

                _summation *= c.DifficultyLevel;
                _expectedValue = _summation / _summationImportance;
                if (_expectedValue > highestValue_)
                {
                    result = c;
                    //highestValue_ = _expectedValue;
                }
            }



            return result;
        }
    }
}
