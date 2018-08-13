using NUnit.Framework;
using Nopie.TDD.BowlingGameKata;
using System;

namespace Nopie.TDD.BowlingGameKataTests
{
    public class FrameTests
    {
        [Test]
        public void Score_WhenAccessedWithoutAnyRoll_ShouldReturnZero()
        {
            var frame = new Frame();
            Assert.That(frame.Score, Is.EqualTo(0));
        }

        [Test]
        public void IsStrike_WhenAccessedWithoutAnyRoll_ShouldReturnFalse()
        {
            var frame = new Frame();
            Assert.IsFalse(frame.IsStrike);
        }

        [Test]
        public void IsSpare_WhenAccessedWithoutAnyRoll_ShouldReturnFalse()
        {
            var frame = new Frame();
            Assert.IsFalse(frame.IsSpare);
        }

        [Test]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void Roll_WhenPassedWithValidPinCount_ShouldNotThrowError(int pinCount)
        {
            var frame = new Frame();

            frame.Roll(pinCount);
            Assert.Pass();
        }


        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void Roll_WhenPassedWithSingleRollPinCountAndValidRollPinCount_ShouldCountAsScore(int firstRollPinCount, int expectedScore)
        {
            var frame = new Frame();

            frame.Roll(firstRollPinCount);

            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        
        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(0, 3, 3)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 3, 4)]
        [TestCase(2, 3, 5)]
        public void Roll_WhenPassedWithValidRollPinCountsAndDoubleRoll_ShouldReturnExpectedScore(int firstRollPinCount, int secondRollPinCount, int expectedScore)
        {
            var frame = new Frame();

            frame.Roll(firstRollPinCount);
            frame.Roll(secondRollPinCount);

            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Roll_WhenCalledMoreThanTwoTimesWithValidPinCount_ShouldThrowInvalidOperationException()
        {
            var frame = new Frame();

            frame.Roll(0);
            frame.Roll(0);
            Assert.Throws<InvalidOperationException>(() => frame.Roll(0));
        }
    }
}