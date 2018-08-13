using System;

namespace Nopie.TDD.FizzBuzzKata
{
    public class FizzBuzz
    {
        public string GetResult(int number)
        {
            if (number < 1 || number > 100)
                throw new ArgumentOutOfRangeException(nameof(number), string.Format("Entered number [{0}] does not meet the rule, entered number should be between 1 and 100", number));

            bool isFizz = number % 3 == 0 || number.ToString().Contains("3");
            bool isBuzz = number % 5 == 0 || number.ToString().Contains("5");

            if (isFizz && isBuzz)
                return "FizzBuzz";
            else if (isFizz)
                return "Fizz";
            else if (isBuzz)
                return "Buzz";

            return number.ToString();
        }        
    }
}
