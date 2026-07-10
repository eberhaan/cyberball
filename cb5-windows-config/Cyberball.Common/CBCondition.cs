using System;
using System.IO;

namespace Cyberball.Common
{
    [Serializable]
    public class CBCondition
    {
        private string name;
        private ScheduleTypes? scheduleType;
        private string welcomeFilePath;
        private string bgImagePath;
        private string scheduleName;
        private CBSchedule customSchedule;
        private bool shouldSpectate;
        private string customConnectingMessage;
        private string customBallImage;
        private string customBoyImagesFolder;

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public ScheduleTypes? ScheduleType
        {
            get { return scheduleType; }

            set { scheduleType = value; }
        }

        public string WelcomeFilePath
        {
            get { return welcomeFilePath; }

            set { welcomeFilePath = value; }
        }

        public string WelcomeFileName
        {
            get { return Path.GetFileName(welcomeFilePath); }
            set { }
        }

        public string BgImagePath
        {
            get { return bgImagePath; }

            set { bgImagePath = value; }
        }

        public string BGImageName
        {
            get { return Path.GetFileName(bgImagePath); }
            set { }
        }

        public string ScheduleName
        {
            get { return scheduleName; }

            set { scheduleName = value; }
        }

        public CBSchedule CustomSchedule
        {
            get { return customSchedule; }

            set { customSchedule = value; }
        }

        public bool ShouldSpectate
        {
            get { return shouldSpectate; }

            set { shouldSpectate = value; }
        }

        public string ThankYouFilePath { get; set; }

        public string ThankYouFileName
        {
            get { return Path.GetFileName(ThankYouFilePath); }
            set { }
        }

        public string WelcomeText { get; set; }
        public string ThankYouText { get; set; }

        public CBCondition(string conditionName) : this()
        {
            Name = conditionName;
        }

        public CBCondition()
        {
            ScheduleType = ScheduleTypes.IncludeAll;
        }

        public string PostExptURL
        {
            get;
            set;
        }

        public string CustomConnectingMessage
        {
            get { return customConnectingMessage; }
            set { customConnectingMessage = value; }
        }

        public string CustomBallImage
        {

            get
            {
                return customBallImage;
            }
            set
            {
                customBallImage = value;
            }
        }

        public string CustomBoyImagesFolder
        {
            get { return customBoyImagesFolder; }

            set
            {
                customBoyImagesFolder = value;
            }
        }
    }
}