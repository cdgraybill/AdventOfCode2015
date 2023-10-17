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
                var action = GetAction_PartOne(line);
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

        public int Solve_Part02()
        {
            int[,] lights = new int[1000, 1000];

            foreach (var line in _problemInput)
            {
                var action = GetAction_PartTwo(line);
                var coordinates = GetCoordinates(line);
                RunInstructions_PartTwo(lights, action, coordinates);
            }

            foreach (var light in lights)
            {
                _numberOfLights += light;
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

        private void RunInstructions_PartTwo(int[,] lights, int action, CoordinateSet coordinates)
        {
            for (int x = coordinates.FirstCoordinate.X; x <= coordinates.SecondCoordinate.X; x++)
            {
                for (int y = coordinates.FirstCoordinate.Y; y <= coordinates.SecondCoordinate.Y; y++)
                {
                    if (action == 1)
                        lights[x, y] += 1;
                    else if (action == -1)
                        lights[x, y] += -1;
                    else
                        lights[x, y] += 2;

                    if (lights[x, y] < 0)
                        lights[x, y] = 0;
                }
            }
        }

        private string GetAction_PartOne(string line)
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

        private int GetAction_PartTwo(string line)
        {
            int action;
            if (line.Contains("on"))
                action = 1;
            else if (line.Contains("off"))
                action = -1;
            else
                action = 2;

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
