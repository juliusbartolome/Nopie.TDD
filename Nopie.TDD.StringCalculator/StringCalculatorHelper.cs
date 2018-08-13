using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nopie.TDD.StringCalculator
{
    public class StringCalculatorHelper
    {
        private readonly string _positiveNumberRegexPattern = "-?([0-9]*)";
        public int Add(string numbersToComputeInStrings)
        {
            List<int> parseNumbers = new List<int>();
            foreach (Match currentMatch in Regex.Matches(numbersToComputeInStrings, _positiveNumberRegexPattern))
            {
                int parsedNumber = 0;
                if (currentMatch.Success && !string.IsNullOrEmpty(currentMatch.Value))
                    parsedNumber = int.Parse(currentMatch.Value);

                if (parsedNumber <= 1000)
                    parseNumbers.Add(parsedNumber);
            }
            
            List<int> negativeNumbers = parseNumbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
                throw new Exception(string.Format("Negative numbers are not allowed: {0}.", string.Join(", ", negativeNumbers)));

            return parseNumbers.Sum();
        }
    }
}
