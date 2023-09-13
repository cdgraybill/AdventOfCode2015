using System.Drawing;
using System.Text;

namespace AdventOfCode2015.Solvers
{
    public class Day03Solver
    {
        private readonly string _problemInput = File.ReadAllText(@"C:\Dev Projects\AdventOfCode2015\AdventOfCode2015\ProblemInputs\Day03Input.txt");
        private int _numberOfHouses = 1;

        public int Solve_Part01()
        {
            var currentLocation = new Point();
            List<Point> houseLocations = GetHouseLocations(currentLocation, _problemInput);

            _numberOfHouses = houseLocations.Distinct().Count();

            return _numberOfHouses;
        }

        public int Solve_Part02()
        {
            var currentLocation = new Point();
            var moveSets = GetMoveSets(_problemInput);

            List<Point> santasHouseLocations = GetHouseLocations(currentLocation, moveSets.SantasMoveSet);
            List<Point> robotsHouseLocations = GetHouseLocations(currentLocation, moveSets.RobotsMoveSet);
            var allLocations = santasHouseLocations.Concat(robotsHouseLocations);

            _numberOfHouses = allLocations.Distinct().Count();

            return _numberOfHouses;
        }

        private List<Point> GetHouseLocations(Point currentLocation, string moveSet)
        {
            var houseLocations = new List<Point>() { new Point() { X = 0, Y = 0 } };

            foreach (var move in moveSet)
            {
                switch (move)
                {
                    case '>':
                        currentLocation.X++;
                        break;
                    case '<':
                        currentLocation.X--;
                        break;
                    case '^':
                        currentLocation.Y++;
                        break;
                    case 'v':
                        currentLocation.Y--;
                        break;
                    default:
                        break;
                };

                houseLocations.Add(currentLocation);
            }

            return houseLocations;
        }

        private MoveSets GetMoveSets(string input)
        {
            var santasMoveSet = new StringBuilder();
            var robotsMoveSet = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                    santasMoveSet.Append(input[i]);
                else
                    robotsMoveSet.Append(input[i]);
            }

            return new MoveSets { SantasMoveSet = santasMoveSet.ToString(), RobotsMoveSet = robotsMoveSet.ToString()};
        }

        internal class MoveSets
        {
            internal string SantasMoveSet { get; set; }
            internal string RobotsMoveSet { get; set; }
        }
    }
}
