using Nopie.TDD.BowlingGameKata;
using NUnit.Framework;

namespace Nopie.TDD.BowlingGameKataTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Roll_WhenPassedByZero_ShouldNotThrowAnError()
        {
            var game = new Game();
            game.Roll(0);
            Assert.Pass();
        }

        public void Score_CanBeCalled()
        {
            var game = new Game();
            game.Score();
            Assert.Pass();
        }
    }
}