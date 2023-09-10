using AdventOfCode2015.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015Tests.SolverTests
{
    public class Day02Tests
    {
        [Fact]
        public void Solve_Part01()
        {
            var solver = new Day02Solver();
            var answer = solver.Solve_Part01();

            Assert.Equal(1598415, answer);
        }
    }
}
