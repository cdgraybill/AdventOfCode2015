using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Solvers
{
    public class Day06Solver
    {
        private readonly List<string> _problemInput = File.ReadLines(@"C:\Dev Projects\AdventOfCode2015\AdventOfCode2015\ProblemInputs\Day06Input.txt").ToList();
        private int _numberOfLights = 0;

        public int Solve_Part01()
        {
            bool[,] lights = new bool[1000,1000];

            foreach(var line in _problemInput)
            {
                var action = GetAction(line);
                var coordinates = GetCoordinates(line);
                RunInstructions(lights, action, coordinates); 
            }

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (lights[x, y] == true)
                        _numberOfLights++;
                }
            }

            return _numberOfLights;
        }

        private void RunInstructions(bool[,] lights, string action, CoordinateSet coordinates)
        {
            for (int x = coordinates.FirstCoordinate.X; x <= coordinates.SecondCoordinate.X; x++)
            {
                for (int y = coordinates.FirstCoordinate.Y; y <= coordinates.SecondCoordinate.Y; y++)
                {
                    if (action == "on")
                        lights[x, y] = true;
                    else if (action == "off")
                        lights[x, y] = false;
                    else
                        lights[x, y] = !lights[x, y];
                }
            }
        }

        private string GetAction(string line)
        {
            string action;
            if (line.Contains("on"))
                action = "on";
            else if (line.Contains("off"))
                action = "off";
            else
                action = "toggle";

            return action;
        }

        private CoordinateSet GetCoordinates(string line)
        {
            var parse = Regex.Replace(line, "[^0-9.]", " ").Trim().Split(" ");
            var firstCoordinate = new Point()
            {
                X = int.Parse(parse[0]),
                Y = int.Parse(parse[1])
            };

            var secondCoordinate = new Point()
            {
                X = int.Parse(parse[parse.Length - 2]),
                Y = int.Parse(parse[parse.Length - 1])
            };

            var coordinateSet = new CoordinateSet
            {
                FirstCoordinate = firstCoordinate,
                SecondCoordinate = secondCoordinate
            };

            return coordinateSet;
        }

        private class CoordinateSet
        {
            public Point FirstCoordinate { get; set; }
            public Point SecondCoordinate { get; set; }
        }
    }
}
