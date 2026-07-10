using System;
using System.Collections.Generic;

namespace Cyberball.Common
{
    public class OstracizeScheduleGen
    {
        private readonly int targetPlayer;
        private readonly int throwsNeededToTarget;
        private readonly int totalThrows;
        private readonly int totalPlayers;

        Random rnd = new Random((int) DateTime.Now.Ticks);

        public OstracizeScheduleGen(int targetPlayer, int throwsNeededToTarget, int totalThrows, int totalPlayers)
        {
            this.targetPlayer = targetPlayer;
            this.throwsNeededToTarget = throwsNeededToTarget;
            this.totalThrows = totalThrows;
            this.totalPlayers = totalPlayers;
        }

        public List<int> Generate()
        {
            var pcWindow = 20f;
            var _20pcof10 = Math.Ceiling(totalThrows*pcWindow/100f);
            var targetThrowProbabMultiplier = 1;
            var throwsMadeTotarget = 0;
            List<int> throws = new List<int>();
            var ballholder = 1;

            if (ballholder == targetPlayer)
                targetThrowProbabMultiplier = 0;

            for (int throwCount = 1; throwCount <= totalThrows; throwCount++)
            {
                if (throwCount <= _20pcof10 && throwsMadeTotarget < throwsNeededToTarget)
                    // Do we need to throw to the target?
                {
                    var probab = targetThrowProbabMultiplier*throwsNeededToTarget/_20pcof10;
                    var shouldThrowToTarget = rnd.NextDouble() <= probab;
                    if (shouldThrowToTarget) //Should we throw to him this time?
                    {
                        ++throwsMadeTotarget;
                        targetThrowProbabMultiplier = 0;
                        throws.Add(targetPlayer);
                        ballholder = targetPlayer;
                    }
                    else //Lets throw to someone else
                    {
                        targetThrowProbabMultiplier += throwsNeededToTarget;
                            //increase the probability of the next throw being thrown to the target
                        ballholder = ThrowToOthers(ballholder, totalPlayers);
                        throws.Add(ballholder);
                    }
                }
                else
                {
                    ballholder = ThrowToOthers(ballholder, totalPlayers);
                    throws.Add(ballholder);
                }
                if (ballholder == 2)
                    //if the last throw was made to player 2 (human). We need to add another throw to any
                {
                    throws.Add(0);
                    ++throwCount;
                }
            }
            foreach (int @throw in throws)
            {
                Console.Write(@throw + ", ");
            }
            return throws;
        }

        private int ThrowToOthers(int ballHolder, int totalPlayers)
        {
            var throwTo = rnd.Next(1, totalPlayers + 1);
            while (throwTo == targetPlayer || throwTo == ballHolder)
            {
                throwTo = rnd.Next(1, totalPlayers + 1);
            }
            return throwTo;
        }
    }
}