using System;

namespace Nopie.TDD.BowlingGameKata
{
    public class Game
    {
        private int currentFrame = 1;
        private int score;

        public int CurrentFrame => currentFrame;

        public int Score()
        {
            return score;
        }

        public void Roll(int pins)
        {
            score += pins;

            if (pins == 10)
                currentFrame += 1;
        }
    }
}
