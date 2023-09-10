using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solvers
{
    public class Day01Solver
    {
        private readonly string _problemInput = File.ReadAllText(@"C:\Dev Projects\AdventOfCode2015\AdventOfCode2015\ProblemInputs\Day01Input.txt");
        private int floor = 0;

        public int Solve_Part01()
        {
            for (int i = 0; i < _problemInput.Length; i++)
            {
                IncrementFloors(i);
            }

            return floor;
        }

        public int Solve_Part02()
        {
            for (int i = 0; i < _problemInput.Length; i++)
            {
                IncrementFloors(i);

                if (floor == -1)
                    return i + 1;
            }

            return floor;
        }

        private void IncrementFloors(int floorPosition)
        {
            if (_problemInput[floorPosition] == '(')
                floor++;
            else
                floor--;
        }
    }
}
