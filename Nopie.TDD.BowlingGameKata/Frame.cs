using System;

namespace Nopie.TDD.BowlingGameKata
{
    public class Frame
    {
        protected readonly int  MaxRolls = 2;
        protected int RollCount;
        public int Score { get; private set; }
        public bool IsStrike { get; private set; }
        public bool IsSpare { get; private set; }

        public void Roll(int pinCount)
        {
            RollCount++;
            if (RollCount > MaxRolls)
                throw new InvalidOperationException();

            Score += pinCount;
        }
    }
}