using System;

namespace Nopie.TDD.FizzBuzzKata
{
    public class FizzBuzz
    {
        public string GetResult(int number)
        {
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
