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
        public void Score_WhenCalled_ShouldReturnZeroByDefault()
        {
            var game = new Game();
            var score = game.Score();
            
            Assert.That(score, Is.EqualTo(0));

        }
    }
}