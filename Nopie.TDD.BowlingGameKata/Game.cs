using System;
using System.Collections.Generic;
using System.Linq;

namespace Nopie.TDD.BowlingGameKata
{
    public class Game
    {
        private List<Frame> gameFrames;

        public IReadOnlyCollection<Frame> GameFrames => gameFrames;
        public Frame CurrentFrame => GameFrames.Last();
        public int CurrentFrameCount => GameFrames.Count;

        public Game()
        {
            gameFrames = new List<Frame> { new Frame() };
        }

        public int Score()
        {
            int gameScore = 0;
            foreach (var frame in gameFrames)
            {
                gameScore += frame.Score;
            }

            return gameScore;
        }

        public void Roll(int pins)
        {
            CurrentFrame.Roll(pins);

            if (CurrentFrame.IsStrike || CurrentFrame.IsSpare)
            {
                gameFrames.Add(new Frame());
            }
        }
    }
}
