using System;
using System.Collections.Generic;
using System.Linq;

namespace Cyberball.Common
{
    [Serializable]
    public class CBConfig
    {
        public Guid ID { get; set; }
        private string gameMode;
        private int throwCount;
        private bool isChatEnabled;
        private bool askIDOnGameEnd;
        private bool shouldShowStats;
        private string logFilePath;
        private string configFolderPath;
        private string scheduleFolderPath;
        private bool shouldHandleRandomAssignment;
        private CBRunMode runMode;
        private List<PlayerNamesColors> playerDetails;
        private string currentConditionName;
        private List<CBCondition> conditions;
        private string email;

        public CBCondition CurrentCondition
        {
            get { return conditions.FirstOrDefault(c => c.Name == currentConditionName); }
        }

        private bool shouldShowPictures;

        public string GameMode
        {
            get { return gameMode; }

            set { gameMode = value; }
        }

        public int ThrowCount
        {
            get { return throwCount; }

            set { throwCount = value; }
        }

        public bool IsChatEnabled
        {
            get { return isChatEnabled; }

            set { isChatEnabled = value; }
        }

        public bool AskIDOnGameEnd
        {
            get { return askIDOnGameEnd; }

            set { askIDOnGameEnd = value; }
        }

        public bool ShouldShowStats
        {
            get { return shouldShowStats; }

            set { shouldShowStats = value; }
        }

        public string LogFilePath
        {
            get { return logFilePath; }

            set { logFilePath = value; }
        }

        public string ConfigFolderPath
        {
            get { return configFolderPath; }

            set { configFolderPath = value; }
        }

        public string ScheduleFolderPath
        {
            get { return scheduleFolderPath; }

            set { scheduleFolderPath = value; }
        }

        public bool ShouldHandleRandomAssignment
        {
            get { return shouldHandleRandomAssignment; }

            set { shouldHandleRandomAssignment = value; }
        }

        public CBRunMode RunMode
        {
            get { return runMode; }

            set { runMode = value; }
        }

        public List<PlayerNamesColors> PlayerDetails
        {
            get { return playerDetails; }

            set { playerDetails = value; }
        }

        public string CurrentConditionName
        {
            get { return currentConditionName; }

            set { currentConditionName = value; }
        }

        public List<CBCondition> Conditions
        {
            get { return conditions; }

            set { conditions = value; }
        }

        public bool ShouldShowPictures
        {
            get { return shouldShowPictures; }

            set { shouldShowPictures = value; }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}