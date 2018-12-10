using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    public class SixthPuzzle : iPuzzle
    {
        FileParser parser = new FileParser();
        string filepath = @"E:\Projects\AdventOfCode\AdventOfCode\Puzzles\puzzle6.txt";
        Dictionary<int, Coordinate> coordinates;

        int maxX;
        int maxY;

        public SixthPuzzle()
        {
            coordinates = parser.ObtainListOfCoordinates(filepath);
            maxX = coordinates.Max(c => c.Value.X) + 1;
            maxY = coordinates.Max(c => c.Value.Y) + 1;
        }

        public string Answer()
        { 
            return Answer1() + Answer2();
        }

        public string Answer1()
        {
            int[,] map = new int[maxX, maxY];
            for (int x = 0; x < maxX; x++)
                for (int y = 0; y < maxY; y++)
                {
                    int[] distance = coordinates.Select(c => (Math.Abs(c.Value.X - x) + Math.Abs(c.Value.Y - y))).ToArray();
                    distance = distance.OrderBy(i => i).ToArray();
                    if (distance[0] != distance[1])
                        foreach (KeyValuePair<int, Coordinate> coordinate in coordinates)
                            if (Math.Abs(coordinate.Value.X - x) + Math.Abs(coordinate.Value.Y - y) == distance[0])
                            {
                                coordinate.Value.Distance++;
                                if (y == 0 || y == maxY - 1 || x == 0 || x == maxX - 1)
                                    coordinate.Value.IsInfinte = true;
                            }
                }
            int highestDistance = coordinates.Where(c => !c.Value.IsInfinte).Select(c => c.Value.Distance).Max();
            return "First answer is " + highestDistance;
        }

        public string Answer2()
        {
            int[,] map = new int[maxX, maxY];
            Coordinate smallestCoordinate = new Coordinate();
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    int[] distances = coordinates.Select(c => (Math.Abs(c.Value.X - x) + Math.Abs(c.Value.Y - y))).ToArray();
                    map[x, y] = distances.Sum();
                    break;
                }
            }
            int[] region = map.Cast<int>().Where(i => i < 10000).OrderBy(i => i).ToArray();
            return "\nAnswer 2: " + region.Count().ToString();
        }
    }
}
