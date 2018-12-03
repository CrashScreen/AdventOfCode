using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    public class ThirdPuzzle
    {
        FileParser parser = new FileParser();
        string filePath = @"E:\Projects\AdventOfCode\AdventOfCode\Puzzles\puzzle3.txt";

        List<Rectangle> rectangleList = new List<Rectangle>();

        public ThirdPuzzle()
        {
            rectangleList = parser.ObtainRectangleList(filePath);
        }

        public string Answer()
        {
            return "Answer 1: " + FirstAnswer();
        }

        private string FirstAnswer()
        {
            List<Rectangle> overlappingList = new List<Rectangle>();
            List<string> overlappingTiles = new List<string>();
            int[,] map = new int[rectangleList.Max(r => r.XRight), rectangleList.Max(r => r.YBottom)];

            foreach (Rectangle rectangle in rectangleList)
            {
                for (int yindex = rectangle.y; yindex < rectangle.YBottom; yindex++)
                {
                    for (int index = rectangle.x; index < rectangle.XRight; index++)
                    {
                        map[index, yindex]++;
                    }
                }
            }
            return map.Cast<int>().Where(x => x >= 2).Count().ToString();
        }
    }
}
