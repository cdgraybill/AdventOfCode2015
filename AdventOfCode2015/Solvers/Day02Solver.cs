using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solvers
{
    public class Day02Solver
    {
        private readonly List<string> _problemInput = File.ReadLines(@"C:\Dev Projects\AdventOfCode2015\AdventOfCode2015\ProblemInputs\Day02Input.txt").ToList();
        private int _squareFeet = 0;

        public int Solve_Part01()
        {
            foreach (var gift in _problemInput)
            {
                var splitStrings = gift.Split("x").Select(measurement => int.Parse(measurement)).ToList();
                var smallestSide = splitStrings.Min();
                var surfaceArea = (2 * (splitStrings[0] * splitStrings[1])) + (2 * (splitStrings[1] * splitStrings[2])) + (2 * (splitStrings[2] * splitStrings[0])) + smallestSide;
                _squareFeet += surfaceArea;
            }

            return _squareFeet;
        }
    }
}
