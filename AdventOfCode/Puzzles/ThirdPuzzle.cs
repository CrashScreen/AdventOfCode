using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    public class ThirdPuzzle : iPuzzle
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
            return "Answer 1: " + FirstAnswer() + "\nAnswer 2: " + SecondAnswer();
        }

        private string FirstAnswer()
        {
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

        private string SecondAnswer()
        {
            List<Rectangle> nonOverLapping = new List<Rectangle>();
            foreach (Rectangle rectangle in rectangleList)
            {
                foreach (Rectangle rectangleB in rectangleList)
                {
                    if(rectangle.id != rectangleB.id && rectangle.isIntersecting(rectangleB))
                        rectangle.isOverlapping = true;
                }
                if (!rectangle.isOverlapping)
                    nonOverLapping.Add(rectangle);
            }
            if (nonOverLapping.Count() == 1)
                return nonOverLapping[0].id.ToString();
            else
                return string.Empty;
        }
    }
}
