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
                var sideOne = splitStrings[0] * splitStrings[1];
                var sideTwo = splitStrings[1] * splitStrings[2];
                var sideThree = splitStrings[2] * splitStrings[0];
                List<int> sideArray = new() { sideOne, sideTwo, sideThree };
                var smallestSide = sideArray.Min();
                var surfaceArea = 2 * sideOne + 2 * sideTwo + 2 * sideThree + smallestSide;
                
                _squareFeet += surfaceArea;
            }

            return _squareFeet;
        }

        public int Solve_Part02()
        {
            foreach (var gift in _problemInput)
            {
                var splitStrings = gift.Split("x").Select(measurement => int.Parse(measurement)).ToList();
                var sideOne = (splitStrings[0] * 2) + (splitStrings[1] * 2);
                var sideTwo = (splitStrings[1] * 2) + (splitStrings[2] * 2);
                var sideThree = (splitStrings[2] * 2) + (splitStrings[0] * 2);
                List<int> sideArray = new() { sideOne, sideTwo, sideThree };
                var smallestSide = sideArray.Min();
                var ribbonForBow = splitStrings[0] * splitStrings[1] * splitStrings[2];
                var totalRibbonNeeded = smallestSide + ribbonForBow;

                _squareFeet += totalRibbonNeeded;
            }

            return _squareFeet;
        }
    }
}
