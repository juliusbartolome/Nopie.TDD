using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nopie.TDD.StringCalculator;

namespace Nopie.TDD.StringCalculatorTests
{
    [TestClass]
    public class StringCalculatorHelperTest
    {
        private StringCalculatorHelper _stringCalculatorHelper;

        [TestInitialize]
        public void TestInitialize()
        {
            _stringCalculatorHelper = new StringCalculatorHelper();
        }

        [TestMethod]
        public void Add_WithEmptyString_ShouldReturnZero()
        {
            string emptyString = string.Empty;

            int result = _stringCalculatorHelper.Add(emptyString);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Add_WithOneNumber_ShouldReturn_TheNumber()
        {
            string oneNumber = "1";

            int result = _stringCalculatorHelper.Add(oneNumber);

            Assert.AreEqual(result, 1);   
        }

        [TestMethod]
        public void Add_WithTwoNumbers_ShouldReturn_TheSumOfTwoNumbers()
        {
            string twoNumbers = "1,2";

            int result = _stringCalculatorHelper.Add(twoNumbers);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Add_WithThreeNumbers_ShouldReturn_TheSumOfThreeNumbers()
        {
            string threeNumbers = "1,2,3";

            int result = _stringCalculatorHelper.Add(threeNumbers);

            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void Add_WithTenNumbers_ShouldReturn_TheSumOfTenNumbers()
        {
            string tenNumbers = "1,2,3,4,5,6,7,8,9,10";

            int result = _stringCalculatorHelper.Add(tenNumbers);

            Assert.AreEqual(result, 55);
        }

        [TestMethod]
        public void Add_WithNumbersAndNewLine_ShouldReturn_TheSumOfNumbers()
        {
            string inputNumbers = "1\n2,3";

            int result = _stringCalculatorHelper.Add(inputNumbers);

            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void Add_WithMultipleConsecutiveDelimitersAndNumber_ShouldReturn_TheCorrectSumNumber()
        {
            string inputNumberWithConsecutiveDelimiter = "//[delim1][delim2]\n” for example “//[*][%]\n1*2%3";

            int result = _stringCalculatorHelper.Add(inputNumberWithConsecutiveDelimiter);

            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void Add_WithDifferentDelimitersAndNumbers_ShouldReturn_TheSumOfNumbers()
        {
            string inputWithMultipleDelimiters = "//;\n1;2";

            int result = _stringCalculatorHelper.Add(inputWithMultipleDelimiters);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Add_WithNumbersGreaterThanNine_ShouldReturn_TheSumOfNumbers()
        {
            string input = "//;\n1(10;20:3";

            int result = _stringCalculatorHelper.Add(input);

            Assert.AreEqual(result, 34);
        }

        [TestMethod, ExpectedException(typeof(Exception), "Negative numbers are not allowed: -1, -55.")]
        public void Add_WithNegativeNumbers_ShoulThrow_ExceptionWithNegativeNumbersInIt()
        {
            string inputWithNegativeNumbers = "-1,3,-55";

            _stringCalculatorHelper.Add(inputWithNegativeNumbers);
        }

        [TestMethod]
        public void Add_WithNumbersGreaterThan1000_ShouldBe_IgnoredInComputation()
        {
            string input = "2,1001,1000";

            int result = _stringCalculatorHelper.Add(input);

            Assert.AreEqual(result, 1002);
        }
    }
}
