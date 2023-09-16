using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solvers
{
    public class Day05Solver
    {
        private readonly List<string> _problemInput = File.ReadLines(@"C:\Dev Projects\AdventOfCode2015\AdventOfCode2015\ProblemInputs\Day05Input.txt").ToList();
        private int _numberOfNiceStrings = 0;

        public int Solve_Part01()
        {
            foreach (var line in _problemInput)
            {
                var hasThreeVowels = HasThreeVowels(line);
                var hasForbiddenString = HasForbiddenString(line);
                var hasRepeatingLetter = HasRepeatingLetter(line);

                if (hasThreeVowels && !hasForbiddenString && hasRepeatingLetter)
                    _numberOfNiceStrings++;
            }

            return _numberOfNiceStrings;
        }

        public int Solve_Part02()
        {
            foreach (var line in _problemInput)
            {
                var hasRepeatingLetter = HasRepeatingLetter(line, 2);
                var hasRepeatingPairs = HasRepeatingPairs(line);

                if (hasRepeatingLetter && hasRepeatingPairs)
                    _numberOfNiceStrings++;
            }

            return _numberOfNiceStrings;
        }

        private bool HasThreeVowels(string input)
        {
            var count = 0;

            foreach(var letter in input)
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                    count++;
            }

            return count >= 3;
        }

        private bool HasForbiddenString(string input)
        {
            if (input.Contains("ab") || input.Contains("cd") || input.Contains("pq") || input.Contains("xy"))
                return true;
            else
                return false;
        }

        private bool HasRepeatingLetter(string input, int gap = 1)
        {
            for (int i = gap; i < input.Length; i++)
            {
                if (input[i] == input[i - gap])
                    return true;
                else
                    continue;
            }

            return false;
        }

        private bool HasRepeatingPairs(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                var currentPair = $"{input[i]}{input[i + 1]}";

                for (int j = i + 2; j < input.Length - 1; j++)
                {
                    var nextPair = $"{input[j]}{input[j + 1]}";

                    if (currentPair == nextPair)
                        return true;
                }
            }

            return false;
        }
    }
}
