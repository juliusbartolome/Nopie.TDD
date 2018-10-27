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

        public List<int> Rolls = new List<int>();
        public Frame NextFrame { get; set; }
        public int Score 
        {
            get
            {
                int score = Rolls.Sum();
                if (NextFrame == null)
                    return score;

                if (IsSpare)
                    score += NextFrame.Rolls.FirstOrDefault();

                return score;
            }
        }
        public bool IsStrike => Rolls.Count == 1 && Rolls[0] == MAX_PIN_COUNT;
        public bool IsSpare => Rolls.Count == MAX_ROLLS && Rolls.Sum() == MAX_PIN_COUNT;
        public bool IsDone => Rolls.Count == MAX_ROLLS || IsStrike || IsSpare;

        public void Roll(int pinCount)
        {
            if (IsValidPinCount(pinCount))
                throw new ArgumentException(string.Format("Pin count should be between {0} and {1}", MIN_PIN_COUNT, MAX_PIN_COUNT), nameof(pinCount));

            if (CanRoll)
                throw new InvalidOperationException(string.Format("{0} can only be called {1} times max.", nameof(Roll), MAX_ROLLS));

            if (HasValidTotalPinCount(pinCount))
                throw new InvalidOperationException(string.Format("Total pins that can be rolled should not exceed {0}.", MIN_PIN_COUNT, MAX_PIN_COUNT));

            Rolls.Add(pinCount);
        }

        private bool IsValidPinCount (int pinCount) => pinCount < MIN_PIN_COUNT || pinCount > MAX_PIN_COUNT;
        private bool CanRoll => Rolls.Count >= MAX_ROLLS;
        private bool HasValidTotalPinCount (int pinCount) => (pinCount + Rolls.Sum()) >  MAX_PIN_COUNT;
    }
}