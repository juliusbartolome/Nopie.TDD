using NUnit.Framework;
using Nopie.TDD.BowlingGameKata;
using System;

namespace Nopie.TDD.BowlingGameKataTests
{
    public class FrameTests
    {
        private Frame frame;

        [SetUp]
        public void Setup()
        {
            frame = new Frame();
        }

        [Test]
        public void NextFrame_WhenAccessedInitially_ShouldReturnNull()
        {
            Assert.That(frame.NextFrame, Is.EqualTo(null));
        }

        [Test]
        public void Score_WhenAccessedWithoutAnyRoll_ShouldReturnZero()
        {
            Assert.That(frame.Score, Is.EqualTo(0));
        }

        [Test]
        [TestCase(5, 5, 10)]
        [TestCase(0, 10, 10)]
        [TestCase(4, 2, 6)]
        [TestCase(2, 2, 4)]
        public void Score_WhenAccessedAfterRoll_ShouldReturnExpectedScore(int firstRoll, int secondRoll, int expectedScore)
        {
            frame.Roll(firstRoll);
            frame.Roll(secondRoll);

            Assert.AreEqual(frame.Score, expectedScore);
        }

        [Test]
        [TestCase(5, 5, 5)]
        [TestCase(0, 10, 4)]
        public void Score_WhenIsSpare_ShouldAddTheFirstRollOfTheNextFrameToScore(int currentFrameFirstRoll, int currentFrameSecondRoll, int nextFrameFirstRoll)
        {
            var expectedScore = currentFrameFirstRoll + currentFrameSecondRoll + nextFrameFirstRoll;
            var nextFrame = new Frame();

            frame.Roll(currentFrameFirstRoll);
            frame.Roll(currentFrameSecondRoll);
            
            frame.NextFrame = nextFrame;
            nextFrame.Roll(nextFrameFirstRoll);

            Assert.That(frame.IsSpare, Is.True);
            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_WhenIsSpare_ShouldAddIgnoreSecondRollOfNextFrame()
        {
            var expectedScore = 15;
            var nextFrame = new Frame();

            frame.Roll(5);
            frame.Roll(5);
            frame.NextFrame = nextFrame;
            nextFrame.Roll(5);
            nextFrame.Roll(5);

            Assert.IsTrue(frame.IsSpare);
            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(0, 10)]
        [TestCase(1, 2)]
        [TestCase(5, 5)]
        public void Score_WhenIsStrike_ShouldAddTheFirstAndSecondRollOfTheNextFrameToScore(int nextFrameFirstRoll, int nextFrameSecondRoll)
        {
            var expectedScore = 10 + nextFrameFirstRoll + nextFrameSecondRoll;
            var nextFrame = new Frame();

            frame.Roll(10);
            frame.NextFrame = nextFrame;
            nextFrame.Roll(nextFrameFirstRoll);
            nextFrame.Roll(nextFrameSecondRoll);

            Assert.That(frame.IsStrike, Is.True);
            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_WhenIsStrikeAndFirstNextFrameIsStrike_ShouldAddSecondNextFrameFirstRoll()
        {
            var expectedScore = 30;
            var firstNextFrame = new Frame();
            var secondNextFrame = new Frame();
            frame.NextFrame = firstNextFrame;
            firstNextFrame.NextFrame = secondNextFrame;

            frame.Roll(10);
            firstNextFrame.Roll(10);
            secondNextFrame.Roll(10);

            Assert.IsTrue(frame.IsStrike);
            Assert.IsTrue(firstNextFrame.IsStrike);
            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_WhenIsStrikeAndNextFrameIsNull_ShouldReturnOriginalScore()
        {
            int expectedScore = 10;

            frame.Roll(10);

            Assert.IsTrue(frame.IsStrike);
            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_WhenIsStrikeAndSecondNextFrameIsNull_ShouldReturnOriginalScore()
        {
            int expectedScore = 20;
            var firstNextFrame = new Frame();
            frame.NextFrame = firstNextFrame;

            frame.Roll(10);
            firstNextFrame.Roll(10);

            Assert.IsTrue(frame.IsStrike);
            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void IsStrike_WhenAccessedWithoutAnyRoll_ShouldReturnFalse()
        {
            Assert.IsFalse(frame.IsStrike);
        }

        [Test]
        public void IsSpare_WhenAccessedWithoutAnyRoll_ShouldReturnFalse()
        {
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

            frame.Roll(firstRollPinCount);
            frame.Roll(secondRollPinCount);

            Assert.That(frame.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Roll_WhenCalledMoreThanTwoTimesWithValidPinCount_ShouldThrowInvalidOperationException()
        {

            frame.Roll(0);
            frame.Roll(0);
            Assert.Throws<InvalidOperationException>(() => frame.Roll(0));
        }

        [Test]
        [TestCase(11)]
        [TestCase(-1)]
        public void Roll_WhenPassedWithInvalidPinCountInFirstRoll_ShouldThrowInvalidArgumentException(int pinCount)
        {
            Assert.Throws<ArgumentException>(() => frame.Roll(pinCount));
        }

        [Test]
        [TestCase(11)]
        [TestCase(-1)]
        public void Roll_WhenPassedWithInvalidPinCountInSecondRoll_ShouldThrowInvalidArgumentException(int pinCount)
        {
            frame.Roll(0);
            Assert.Throws<ArgumentException>(() => frame.Roll(pinCount));
        }

        [Test]
        [TestCase(10, 10)]
        public void Roll_WhenPassedWithInvalidTotalPinCountInTwoRolls_ShouldThrowInvalidOperationtException(int firstRollPinCount, int secondRollPinCount)
        {
            frame.Roll(firstRollPinCount);
            Assert.Throws<InvalidOperationException>(() => frame.Roll(secondRollPinCount));
        }

        [Test]
        public void Roll_WhenPassedWithTenPinCountInOneRoll_ShouldSetProperty_IsStrikeToTrueAndIsSpareToFalse()
        {
            
            frame.Roll(10);
            
            Assert.IsTrue(frame.IsStrike);
            Assert.IsFalse(frame.IsSpare);
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(2, 8)]
        public void Roll_WhenPassedWithTenPinCountInTwoRolls_ShouldSetProperty_IsSpaceToTrueIsStrikeToFalse(int firstRollPinCount, int secondRollPinCount)
        {
            
            frame.Roll(firstRollPinCount);
            frame.Roll(secondRollPinCount);

            Assert.IsTrue(frame.IsSpare);
            Assert.IsFalse(frame.IsStrike);
        }

        [Test]
        public void Roll_WhenCalledMoreThanMaxRolls_ShouldThrowAnInvalidOperationException()
        {
            for (int i = 0; i < Frame.MAX_ROLLS; i++)
            {
                frame.Roll(0);
            }

            Assert.Throws<InvalidOperationException>(() => frame.Roll(0));
        }

        [Test]
        public void IsDone_WhenAccessed_WithoutAnyRoll_ShouldReturnFalse()
        {
            Assert.IsFalse(frame.IsDone);
        }

        [Test]
        public void IsDone_WhenAccessed_WithFrameIsSpare_ShouldReturnTrue()
        {
            frame.Roll(0);
            frame.Roll(10);

            Assert.IsTrue(frame.IsSpare);
            Assert.IsTrue(frame.IsDone);
        }

        [Test]
        public void IsDone_WhenAccessed_WithFrameIsStrike_ShouldReturnTrue()
        {
            frame.Roll(10);

            Assert.IsTrue(frame.IsStrike);
            Assert.IsTrue(frame.IsDone);
        }

        [Test]
        public void IsDone_WhenAccessed_WithRollsEqualToMaxRolls_EvenWithoutRolledPins_ShouldReturnTrue()
        {
            for (int i = 0; i < Frame.MAX_ROLLS; i++)
            {
                frame.Roll(0);
            }

            Assert.IsTrue(frame.IsDone);
        }

        [Test]
        public void IsDone_WhenAccess_WithRollLessThanMaxRolls_WithoutRolledPins_ShouldReturnFalse()
        {
            for (int i = 0; i < Frame.MAX_ROLLS - 1; i++)
            {
                frame.Roll(0);
            }

            Assert.IsFalse(frame.IsDone);
        }
    }
}