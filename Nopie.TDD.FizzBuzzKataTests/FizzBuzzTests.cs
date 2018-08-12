using NUnit.Framework;
using Nopie.TDD.FizzBuzzKata;
using System;

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
        [TestCase(1, "1")]
        public void GetResult_WhenPassedWithOne_ShouldReturn_One(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        [TestCase(9, "Fizz")]
        public void GetResult_WhenPassedWithNumberDivisibleByThree_ShouldReturn_Fizz(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(5, "Buzz")]
        [TestCase(10, "Buzz")]
        public void GetResult_WhenPassedWithNumberDivisibleByFive_ShouldReturn_Buzz(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        public void GetResult_WhenPassedWithNumberDivisibleByThreeAndFive_ShouldReturn_FizzBuzz(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(13, "Fizz")]
        [TestCase(23, "Fizz")]
        public void GetResult_WhenPassedWithNumberThree_ShouldReturn_Fizz(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(25, "Buzz")]
        [TestCase(65, "Buzz")]
        [TestCase(100, "Buzz")]
        public void GetResult_WhenPassedWithNumberFive_ShouldReturn_Buzz(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(35, "FizzBuzz")]
        [TestCase(53, "FizzBuzz")]
        public void GetResult_WhenPassedWithNumberThreeAndFive_ShouldReturn_FizzBuzz(int number, string expectedResult)
        {
            var actualResult = _fizzBuzz.GetResult(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(101)]
        public void GetResult_WhenPassedWithNumberLessThanOne_ShouldThrow_ArgumentOutOfRangeException(int number)
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _fizzBuzz.GetResult(number));
            Assert.That(exception.Message, Is.EqualTo(string.Format("Entered number [{0}] does not meet the rule, entered number should be between 1 and 100\nParameter name: number", number)));
        }
    }
}