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
        public void CurrentFrame_WhenCalled_BeforeAnyRoll_ShouldReturnOne()
        {
            Assert.That(sutGame.CurrentFrame, Is.EqualTo(1));
        }

        [Test]
        public void CurrentFrame_WhenCalled_AfterRollingTenPins_ShouldIncrementCurrentFrameByOne()
        {
            var expectedCurrentFrame = sutGame.CurrentFrame + 1;

            sutGame.Roll(10);

            Assert.That(sutGame.CurrentFrame, Is.EqualTo(expectedCurrentFrame));
        }

        [Test]
        public void CurrentFrame_WhenCalled_AfterRollingPinsLessThanTen_ShouldNotIncrementCurrentFrame()
        {
            var expectedCurrentFrame = sutGame.CurrentFrame;

            sutGame.Roll(9);

            Assert.That(sutGame.CurrentFrame, Is.EqualTo(expectedCurrentFrame));
        }
    }
}