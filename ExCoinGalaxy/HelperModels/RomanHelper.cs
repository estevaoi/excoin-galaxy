using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExCoinGalaxy.HelperModels
{
    public static class RomanHelper
    {

        private static readonly Dictionary<char, int> _numerals = new Dictionary<char, int>
    {
      { 'I', 1 },
      { 'V', 5 },
      { 'X', 10 },
      { 'L', 50 },
      { 'C', 100 },
      { 'D', 500 },
      { 'M', 1000 },
    };

        private static readonly char[] _noRepeatRoman = new char[] { 'D', 'L', 'V' };
        private static readonly char[] _noRepeatSuccessively = new char[] { 'I', 'X', 'C', 'M' };

        private static readonly Dictionary<int, int[]> _subtract = new Dictionary<int, int[]>
    {
      {_numerals['I'], new int[] { _numerals['V'], _numerals['X'] } },
      {_numerals['V'], new int[] { } },
      {_numerals['X'], new int[] { _numerals['L'], _numerals['C'] } },
      {_numerals['L'], new int[] { } },
      {_numerals['C'], new int[] { _numerals['D'], _numerals['M'] } },
      {_numerals['D'], new int[] { } },
      {_numerals['M'], new int[] { } }
    };

        public static int RomanToInt(string roman)
        {
            // Check the rules
            string errorMessage;
            if (!isValid(roman, out errorMessage))
            {
                throw new Exception(errorMessage);
            }

            // Convert roman to integer number
            int finalNumber = 0, lastNumber = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                char c = roman[i];

                finalNumber = processNumber(_numerals[c], lastNumber, finalNumber);
                lastNumber = _numerals[c];
            }

            return finalNumber;
        }

        private static bool isValid(string roman, out string errorMessage)
        {
            // Validate non repeat roman numbers
            foreach (char c in _noRepeatRoman)
            {
                if (roman.Count(x => x == c) > 1)
                {
                    errorMessage = string.Format("Roman number {0} cannot be repeated", String.Join(", ", _noRepeatRoman));
                    return false;
                }
            }

            // Validate 4 times successively roman numbers
            foreach (char c in _noRepeatSuccessively)
            {
                string aux = String.Concat(Enumerable.Repeat(c, 4));
                if (roman.Contains(aux))
                {
                    errorMessage = string.Format("Roman number {0} cannot repeat 4 times successively", String.Join(", ", _noRepeatSuccessively));
                    return false;
                }
            }

            errorMessage = string.Empty;
            return true;
        }

        private static int processNumber(int number, int lastNumber, int finalNumber)
        {
            if (lastNumber > number)
            {
                return subtract(number, lastNumber, finalNumber);
            }
            else
            {
                return finalNumber + number;
            }
        }

        private static int subtract(int number, int lastNumber, int finalNumber)
        {
            if (_subtract[number].Contains(lastNumber))
            {
                return finalNumber - number;
            }
            else
            {
                return finalNumber + number;
            }
        }
    }
}
