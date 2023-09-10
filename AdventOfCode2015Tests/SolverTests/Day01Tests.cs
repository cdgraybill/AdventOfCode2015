using AdventOfCode2015.Solvers;

namespace AdventOfCode2015Tests.SolverTests
{
    public class Day01Tests
    {
        [Fact]
        public void Solve_Part01()
        {
            var solver = new Day01Solver();
            var answer = solver.Solve_Part01();

            Assert.Equal(280, answer);
        }

        [Fact]
        public void Solve_Part02()
        {
            var solver = new Day01Solver();
            var answer = solver.Solve_Part02();

            Assert.Equal(1797, answer);
        }
    }
}