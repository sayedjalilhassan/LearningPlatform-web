using System;
using System.Configuration;

namespace LearningPlatform.Models
{
    public class ApplicationSettings
    {
        private static object _threadLock = new Object();
        private static ApplicationSettings _Instance = null;

        private string _ApplicationName;
        private string _Author;
        private string _DevelopmentTime;
        private string _DeploymentVirtualDirectory;

        public string ApplicationName { get { return _ApplicationName; } }
        public string Author { get { return _Author; } }
        public string DevelopmentTime { get { return _DevelopmentTime; } }
        public string DeploymentVirtualDirectory { 
            get { return _DeploymentVirtualDirectory; } }

        private ApplicationSettings()
        {
            _ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
            _Author = ConfigurationManager.AppSettings["Author"];
            _DevelopmentTime = ConfigurationManager.AppSettings["DevelopmentTime"];
            _DeploymentVirtualDirectory
                = ConfigurationManager.AppSettings["DeploymentVirtualDirectory"];
        }

        public static ApplicationSettings GetInstance()
        {
            lock (_threadLock)
                if (_Instance == null)
                    _Instance = new ApplicationSettings();

            return _Instance;
        }

    }
}
