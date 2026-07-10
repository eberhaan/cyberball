using System;

namespace Cyberball.Common
{
    [Serializable]
    public class PlayerNamesColors
    {
        public string PlayerNumForGrid
        {
            get
            {
                if (PlayerNum.Contains("2"))
                {
                    return PlayerNum + " (Human)";
                }
                return PlayerNum;
            }
        }

        public string PlayerNum { get; set; }
        public string PlayerName { get; set; }
        public string PlayerColor { get; set; }
        public string PlayerPic { get; set; }

        public int PlayerColorRed
        {
            get { return int.Parse(PlayerColor.Substring(1, 2), System.Globalization.NumberStyles.HexNumber)*100/255; }
            set { }
        }

        public int PlayerColorGreen
        {
            get { return int.Parse(PlayerColor.Substring(3, 2), System.Globalization.NumberStyles.HexNumber)*100/255; }
            set { }
        }

        public int PlayerColorBlue
        {
            get { return int.Parse(PlayerColor.Substring(5, 2), System.Globalization.NumberStyles.HexNumber)*100/255; }
            set { }
        }
    }
}