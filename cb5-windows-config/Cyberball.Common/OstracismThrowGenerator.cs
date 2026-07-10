using System;

namespace Cyberball.Common
{
    public class OstracismThrowGenerator : IThrowGenerator
    {
        private int _playerCount;
        private int _throwsMadeToSubject;

        private Random _rnd;
        private int _whomToOstracize;
        private readonly int _maxThrowsToVictim;
        private readonly int _totalThrows;
        private int _victimThrowInterval;

        private readonly float _victimThrowWindowPercent = .3f;

        private int _throwCounter;

        public OstracismThrowGenerator(int playerCount, int victim, int maxThrowsToVictim, int totalThrows)
        {
            _playerCount = playerCount;
            _whomToOstracize = victim;
            _maxThrowsToVictim = maxThrowsToVictim;
            _totalThrows = totalThrows;

            if (maxThrowsToVictim != 0)
                _victimThrowInterval = (int) Math.Ceiling(totalThrows*_victimThrowWindowPercent/maxThrowsToVictim);
            else
                _victimThrowInterval = int.MaxValue;

            _rnd = new Random((int) DateTime.Now.Ticks);
        }

        public int GetNextThrow(int prevPlayer)
        {
            ++_throwCounter;
            var nextPlayer = _rnd.Next(1, _playerCount + 1);
            while (nextPlayer == prevPlayer ||
                   (nextPlayer == _whomToOstracize && _throwsMadeToSubject == _maxThrowsToVictim))
            {
                nextPlayer = _rnd.Next(1, _playerCount + 1);
            }
            if (nextPlayer == _whomToOstracize)
            {
                ++_throwsMadeToSubject;
            }

            return nextPlayer;
        }
    }
}