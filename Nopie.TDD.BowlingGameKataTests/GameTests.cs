using Nopie.TDD.BowlingGameKata;
using NUnit.Framework;

namespace Nopie.TDD.BowlingGameKataTests
{
    public class GameTests
    {
        private Game sutGame;

        [SetUp]
        public void Setup()
        {
            sutGame = new Game();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Score_WhenCalled_ShouldReturnZeroByDefault()
        {
            Assert.That(sutGame.Score(), Is.EqualTo(0));
        }

        [Test]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(1)]
        [TestCase(0)]
        public void Score_WhenCalled_AfterFirstRoll_ShouldReturnThePins(int pins)
        {
            sutGame.Roll(pins);
            
            Assert.That(sutGame.Score(), Is.EqualTo(pins));
        }

        [Test]
        [TestCase(5, 0)]
        [TestCase(6, 3)]
        public void Score_WhenCalled_AfterSecondRoll_WhereTotalPinsRolledAreLessThanTen_ShouldReturnTheTotalPinsOfBothRolls(int firstRollPins, int secondRollPins)
        {
            var expectedScore = firstRollPins + secondRollPins;
            sutGame.Roll(firstRollPins);
            sutGame.Roll(secondRollPins);

            Assert.That(sutGame.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        public void CurrentFrameCount_WhenCalled_BeforeAnyRoll_ShouldReturnOne()
        {
            Assert.That(sutGame.CurrentFrameCount, Is.EqualTo(1));
        }

        [Test]
        public void CurrentFrameCount_WhenCalled_AfterRollingTenPins_ShouldIncrementCurrentFrameCountByOne()
        {
            var expectedCurrentFrameCount = sutGame.CurrentFrameCount + 1;

            sutGame.Roll(10);

            Assert.That(sutGame.CurrentFrameCount, Is.EqualTo(expectedCurrentFrameCount));
        }

        [Test]
        public void CurrentFrameCount_WhenCalled_AfterRollingPinsLessThanTen_ShouldNotIncrementCurrentFrameCount()
        {
            var expectedCurrentFrameCount = sutGame.CurrentFrameCount;

            sutGame.Roll(9);

            Assert.That(sutGame.CurrentFrameCount, Is.EqualTo(expectedCurrentFrameCount));
        }

        [Test]
        public void CurrentFrameCount_WhenCalled_AfterRollingThreeTimes_ShouldIncrementCurrentFrameCount()
        {
            int expectedCurrentFrameCount = sutGame.CurrentFrameCount + 1;

            sutGame.Roll(1);
            sutGame.Roll(1);
            sutGame.Roll(1);

            Assert.That(sutGame.CurrentFrameCount, Is.EqualTo(expectedCurrentFrameCount));
        }

        [Test]
        public void CurrentFrame_WhenAccessed_OnInitialState_ShouldBeNull()
        {
            Assert.IsNotNull((sutGame.CurrentFrame));
            Assert.IsNull(sutGame.CurrentFrame.NextFrame);
        }

        [Test]
        public void CurrentFrame_WhenAccessed_AfterFrameIsDone_ShouldContainTheCurrentFrameAsItsNextFrame()
        {
            Frame currentFrame = sutGame.CurrentFrame;

            sutGame.Roll(10);

            Assert.IsTrue(currentFrame.IsDone);
            Assert.That(currentFrame.NextFrame, Is.EqualTo(sutGame.CurrentFrame));
        }

        [Test]
        [TestCase(7, 2, 28)]
        [TestCase(5, 5, 30)]
        [TestCase(10, 10, 60)]
        public void Score_WhenCalled_AfterStrikeFrameAndTwoRolls_ShouldCalculateAccordingly(int nextFrameFirstRoll, int nextFrameSecondRoll, int expectedScore)
        {
            sutGame.Roll(10);
            sutGame.Roll(nextFrameFirstRoll);
            sutGame.Roll(nextFrameSecondRoll);

            Assert.That(sutGame.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        [TestCase(5, 20)]
        [TestCase(10, 30)]
        public void Score_WhenCalled_AfterSpareFrameAndOneRoll_ShouldCalculateAccordingly(int nextFrameFirstRoll, int expectedScore)
        {
            sutGame.Roll(5);
            sutGame.Roll(5);
            sutGame.Roll(nextFrameFirstRoll);

            Assert.That(sutGame.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_WhenCalled_AfterSpareFrameAndTwoRolls_ShouldCalculateAccordingly()
        {
            int expectedScore = 25;
            sutGame.Roll(5);
            sutGame.Roll(5);
            sutGame.Roll(5);
            sutGame.Roll(5);

            Assert.That(sutGame.Score(), Is.EqualTo(expectedScore));
        }
    }
}