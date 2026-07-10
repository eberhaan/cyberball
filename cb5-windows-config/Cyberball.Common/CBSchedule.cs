using System.Collections.Generic;

namespace Cyberball.Common
{
    public class CBSchedule
    {
        public string Name { get; set; }

        public int PlayerCount
        {
            get { return playerCount; }
            set
            {
                playerCount = value;
                if (playerCount > 9)
                    playerCount = 9;
            }
        }

        private int playerCount;
        public List<CBThrow> throws;

        public int GetThrowCount()
        {
            return throws?.Count ?? 0;
        }

        public void AddThrow()
        {
            if (throws == null)
                throws = new List<CBThrow>();
            throws.Add(new CBThrow());
        }

        public CBThrow GetThrowAt(int throwIndex)
        {
            return throws?[throwIndex];
        }

        public void UpdateThrow(int throwIndex, string throwTo, decimal throwDelay)
        {
            if (throws == null) return;

            throws[throwIndex].Delay = (int)throwDelay;
            throws[throwIndex].ThrowTo = throwTo;
        }

        public void AddThrow(CBThrow cBThrow)
        {
            if (throws == null)
                throws = new List<CBThrow>();
            throws.Add(cBThrow);
        }

        public string GetBallHolderName()
        {
            if (throws == null || throws.Count == 0)
                return "Player 1";
            return throws[throws.Count - 1].ThrowTo;
        }

        public void UpdateThrow(int throwIndex, CBThrow cbThrow)
        {
            throws[throwIndex] = cbThrow;
        }

        public void DeleteThrowAt(int selectedIndex)
        {
            throws.RemoveAt(selectedIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="throwIndex"></param>
        /// <returns>True if a throw was moved</returns>
        public bool MoveThrowUpAt(int throwIndex)
        {
            if (throws == null || throwIndex < 0 || throwIndex >= throws.Count)
                return false;

            //First element cannot be moved up
            if (throwIndex == 0)
                return false;

            var tempThrow = throws[throwIndex];
            throws[throwIndex] = throws[throwIndex - 1];
            throws[throwIndex - 1] = tempThrow;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="throwIndex"></param>
        /// <returns>True if throw was moved</returns>
        public bool MoveThrowDownAt(int throwIndex)
        {
            if (throws == null || throwIndex < 0 || throwIndex >= throws.Count)
                return false;

            //Last element cannot be moved down
            if (throwIndex == (throws.Count - 1))
                return false;

            var tempThrow = throws[throwIndex];
            throws[throwIndex] = throws[throwIndex + 1];
            throws[throwIndex + 1] = tempThrow;
            return true;
        }

        public void AddMessage(CBMessage cbMessage)
        {
            if (throws == null)
                throws = new List<CBThrow>();

            var throwname = string.Empty;


            if (cbMessage.sender != 0)
            {
                throwname = "Chat - " + "P" + cbMessage.sender + " - " + cbMessage.message;
            }
            else
            {
                throwname = "Instr. - " + cbMessage.message;
            }

            var newThrow = new CBThrow
            {
                isChatMessage = true,
                IsInstruction = cbMessage.sender == 0,
                msg = cbMessage,
                ThrowName = throwname 
            };
            newThrow.msg.SetParentThrow(newThrow);
            throws.Add(newThrow);
        }

        public string GetPrevPlayerName(int index)
        {
            if (throws == null || throws.Count == 0 || index == 0)
                return "Player 1";
            const string prevPlayer = "Player 1";
            var currIndex = index;

            while (currIndex >= 1)
            {
                if (throws[currIndex - 1].isChatMessage)
                {
                    currIndex--;
                }
                else
                {
                    return throws[currIndex - 1].ThrowTo;
                }
            }
            return prevPlayer;
        }

        public int GetDeprecatedThrowCount()
        {
            var depThr = 0;
            if (throws == null) return 0;

            for (int i = 0; i < throws.Count; i++)
            {
                if (GetPrevPlayerName(i).ToLower().Contains("any")) depThr++;
            }
            return depThr;
        }
    }
}