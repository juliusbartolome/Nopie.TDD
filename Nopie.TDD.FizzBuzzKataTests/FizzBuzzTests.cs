using NUnit.Framework;
using Nopie.TDD.FizzBuzzKata;

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
        public void GetResult_WhenPassedWithZero_ShouldReturn_Zero(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}