using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solvers
{
    public class Day04Solver
    {
        private readonly string _problemInput = File.ReadAllText(@"C:\Dev Projects\AdventOfCode2015\AdventOfCode2015\ProblemInputs\Day04Input.txt");
        private int number = 0;

        public int Solve_Part01()
        {
            var isStillLooking = true;

            while (isStillLooking)
            {
                var computeInput = $"{_problemInput}{number}";
                var md5 = MD5.Create();
                byte[] encodedPassword = new UTF8Encoding().GetBytes(computeInput);
                byte[] hash = md5.ComputeHash(encodedPassword); 
                string encoded = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToLower();
                var firstFive = encoded[..5];

                if (firstFive == "00000")
                    break;
                else
                    number++;
            }

            return number;
        }

        public int Solve_Part02()
        {
            var isStillLooking = true;

            while (isStillLooking)
            {
                var computeInput = $"{_problemInput}{number}";
                var md5 = MD5.Create();
                byte[] encodedPassword = new UTF8Encoding().GetBytes(computeInput);
                byte[] hash = md5.ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToLower();
                var firstSix = encoded[..6];

                if (firstSix == "000000")
                    break;
                else
                    number++;
            }

            return number;
        }
    }
}
