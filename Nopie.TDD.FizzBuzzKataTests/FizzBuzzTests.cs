using NUnit.Framework;

namespace Nopie.TDD.FizzBuzzKataTests
{
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;
        [SetUp]
        public void Setup()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [TearDown]
        public void TearDown()
        {
            _fizzBuzz = null;
        }

        [Test]
        [TestCase(0, "0")]
        public void GetResult_PassingZeroAsArgument_ShouldReturn_Zero(int zeroNumber, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(zeroNumber);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}