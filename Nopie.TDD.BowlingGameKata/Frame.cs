using System;
using System.Collections.Generic;
using System.Linq;

namespace Nopie.TDD.BowlingGameKata
{
    public class Frame
    {
        public const int  MAX_ROLLS = 2;
        private const int MAX_PIN_COUNT = 10;
        private const int MIN_PIN_COUNT = 0;
        private List<int> _rolls = new List<int>();

        public int Score => _rolls.Sum();
        public bool IsStrike => _rolls.Count == 1 && _rolls[0] == MAX_PIN_COUNT;
        public bool IsSpare => _rolls.Count == MAX_ROLLS && Score == MAX_PIN_COUNT;

        public bool IsDone => _rolls.Count == MAX_ROLLS || IsStrike || IsSpare;

        public void Roll(int pinCount)
        {
            if (pinCount < MIN_PIN_COUNT || pinCount > MAX_PIN_COUNT)
                throw new ArgumentException(string.Format("Pin count should be between {0} and {1}", MIN_PIN_COUNT, MAX_PIN_COUNT), nameof(pinCount));

            if ((pinCount + Score) >  MAX_PIN_COUNT)
                throw new InvalidOperationException(string.Format("Total pins that can be rolled should not exceed {0}.", MIN_PIN_COUNT, MAX_PIN_COUNT));

            if (_rolls.Count >= MAX_ROLLS)
                throw new InvalidOperationException(string.Format("{0} can only be called {1} times max.", nameof(Roll), MAX_ROLLS));

            _rolls.Add(pinCount);
        }
    }
}